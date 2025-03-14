﻿using Dominio;
using Dominio.Aplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Formularios.Administracion.Empleados;
using UI.Formularios.Pedidos;
using static UI.ValidacionesForm;

namespace UI.Formularios.Proyectos
{
    public partial class FormDetalleProyecto : Form
    {
        private static FormDetalleProyecto instance;
        private Proyecto esteProyecto;
        private List<Integrante> listaIntegrantes;

        private FormDetalleProyecto()
        {
            InitializeComponent();
            comboBoxEstadoProyecto.SelectedIndex = 0;
            if (listaIntegrantes == null)
            {
                listaIntegrantes = new List<Integrante>();
            }
            Empleado empleadoEnSesion = CN_Empleados.ObtenerInstancia().ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User);
            Integrante creador = new Integrante
            {
                Nombre = empleadoEnSesion.Nombre,
                ID_Empleado = empleadoEnSesion.ID_Empleado,
                ID_Proyecto = string.IsNullOrWhiteSpace(textBoxNumero.Text) ? 0 : int.Parse(textBoxNumero.Text),
                Cargo = "Administrador"
            };
            listaIntegrantes.Add(creador);
            CargarEmpleados(listaIntegrantes);
        }

        private FormDetalleProyecto(Proyecto proyecto) : this()
        {
            esteProyecto = proyecto;
            RellenarCampos();
        }

        public static FormDetalleProyecto ObtenerInstancia(Proyecto proyecto = null)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = proyecto == null ? new FormDetalleProyecto() : new FormDetalleProyecto(proyecto);
            }
            return instance;
        }
        
        private void RellenarCampos()
        {
            textBoxNumero.Text = esteProyecto.ID_Proyecto.ToString();
            textBoxNombre.Text = esteProyecto.Nombre;
            comboBoxEstadoProyecto.Text = esteProyecto.Estado.ToString();
            dateTimePickerInicio.Value = esteProyecto.FechaInicio;
            dateTimePickerFin.Value = esteProyecto.FechaFin;
            listaIntegrantes = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(esteProyecto.ID_Proyecto);
            CargarEmpleados(listaIntegrantes);
            listaPedidos = CN_Proyectos.ObtenerInstancia().ObtenerPEDIDOSxPROYECTO(esteProyecto.ID_Proyecto);
            CargarPEDIDOSxPROYECTO(listaPedidos);
        }
        private void CargarEmpleados(List<Integrante> listaDeIntegrantes)
        {
            // Configurar DataGridView
            dataGridViewEmpleados.AutoGenerateColumns = false;
            dataGridViewEmpleados.Columns.Clear();

            // Crear columnas manualmente
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            colNombre.ReadOnly = true; // Solo lectura
            dataGridViewEmpleados.Columns.Add(colNombre);

            DataGridViewComboBoxColumn colCargo = new DataGridViewComboBoxColumn();
            colCargo.Name = "Cargo";
            colCargo.DataPropertyName = "Cargo";
            colCargo.DataSource = new string[] { "Administrador", "Observador", "Colaborador" }; // Opciones para el combo
            colCargo.ReadOnly = false;
            dataGridViewEmpleados.Columns.Add(colCargo);

            // Asignar la lista de integrantes al DataGridView
            dataGridViewEmpleados.DataSource = listaDeIntegrantes;
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool EsAdministrador()
        {
            if (string.IsNullOrWhiteSpace(textBoxNumero.Text))
            {
                if (HayAdministrador())
                {
                    return true;
                }
                
                int idEmpleadoActual = CN_Empleados.ObtenerInstancia()
        .ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User)
        .ID_Empleado;

                foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
                {
                    if (row.DataBoundItem is Integrante integrante &&
                        integrante.ID_Empleado == idEmpleadoActual &&
                        integrante.Cargo == "Administrador")
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return CN_Proyectos.ObtenerInstancia().ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(esteProyecto.ID_Proyecto).Any(i => i.ID_Empleado == CN_Empleados.ObtenerInstancia().ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User).ID_Empleado && i.Cargo == "Administrador");

            }
        }
        private bool HayAdministrador()
        {
            foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
            {
                if (row.DataBoundItem is Integrante integrante && integrante.Cargo == "Administrador")
                {
                    return true;
                }
            }
            return false;
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show("Usted no tiene el cargo Administrador en este proyecto, no puede realizar cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!HayAdministrador())
            {
                MessageBox.Show("El proyecto debe tener al menos un Administrador, verifique la pestaña Empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!VerificarCampos())
            {
                MessageBox.Show("Verifique los campos del formulario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Proyecto proyecto = new Proyecto
            {
                ID_Proyecto = string.IsNullOrWhiteSpace(textBoxNumero.Text) ? 0 : int.Parse(textBoxNumero.Text),
                Nombre = textBoxNombre.Text.Trim(),
                FechaInicio = dateTimePickerInicio.Value,
                FechaFin = dateTimePickerFin.Value,
                Estado = comboBoxEstadoProyecto.Text
            };

            int filasAfectadas;

            // Determinar si se trata de un nuevo proyecto o de una modificación
            if (proyecto.ID_Proyecto == 0)
            {
                // Alta de nuevo proyecto
                filasAfectadas = CN_Proyectos.ObtenerInstancia().AltaProyecto(proyecto);
                List<Proyecto> listaProyectos = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosProyectos();
                Proyecto ultimoProyecto = listaProyectos.OrderByDescending(p => p.ID_Proyecto).FirstOrDefault();
                textBoxNumero.Text = ultimoProyecto.ID_Proyecto.ToString();
                esteProyecto = ultimoProyecto;
                foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
                {
                    if (row.DataBoundItem is Integrante integrante)
                    {
                        integrante.ID_Proyecto = ultimoProyecto.ID_Proyecto;
                    }
                }
                foreach (DataGridViewRow row in dataGridViewPedidos.Rows)
                {
                    if (row.DataBoundItem is PEDIDOxPROYECTO integrante)
                    {
                        integrante.ID_Proyecto = ultimoProyecto.ID_Proyecto;
                    }
                }
            }
            else
            {
                // Modificación de proyecto existente
                filasAfectadas = CN_Proyectos.ObtenerInstancia().ModificarProyecto(proyecto);
            }
            GuardarEmpleados();
            GuardarPEDIDOSxPROYECTO();
            MessageBox.Show(filasAfectadas > 0
                ? "Proyecto guardado correctamente."
                : "No se pudo completar la operación.");
        }
        private void GuardarEmpleados()
        {
            List<Integrante> listaIntegrantes = new List<Integrante>();
            foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
            {
                if (!row.IsNewRow)
                {
                    Integrante integrante = (Integrante)row.DataBoundItem;
                    integrante.Cargo = row.Cells["Cargo"].Value.ToString();
                    listaIntegrantes.Add(integrante);
                }
            }
            int resultado = CN_Proyectos.ObtenerInstancia().ModificarEmpleadosxProyecto(listaIntegrantes, esteProyecto.ID_Proyecto);        
        }
        private bool VerificarCampos()
        {
            errorProvider1.Clear();
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                errorProvider1.SetError(textBoxNombre, "El nombre no puede estar vacío");
                esValido = false;
            }

            if (dateTimePickerInicio.Value > dateTimePickerFin.Value)
            {
                errorProvider1.SetError(dateTimePickerFin, "La fecha de fin debe ser igual o posterior a la de inicio.");
                esValido = false;
            }

            return esValido;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show("Usted no tiene el cargo Administrador en este proyecto, no puede realizar cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormGestionarEmpleados form = FormGestionarEmpleados.ObtenerInstancia(1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Empleado empleadoSeleccionado = form.EmpleadoSeleccionado;
                if (listaIntegrantes == null)
                {
                    listaIntegrantes = new List<Integrante>();
                }
                if (empleadoSeleccionado != null && !listaIntegrantes.Any(i => i.ID_Empleado == empleadoSeleccionado.ID_Empleado))
                {
                    Integrante nuevoIntegrante = new Integrante
                    {
                        Nombre = empleadoSeleccionado.Nombre,
                        ID_Empleado = empleadoSeleccionado.ID_Empleado,
                        ID_Proyecto = string.IsNullOrWhiteSpace(textBoxNumero.Text) ? 0 : int.Parse(textBoxNumero.Text),
                        Cargo = "Colaborador"
                    };
                    // List<Integrante> listaIntegrantes = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(esteProyecto.ID_Proyecto);
                    listaIntegrantes.Add(nuevoIntegrante);
                    CargarEmpleados(listaIntegrantes);
                }
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show("Usted no tiene el cargo Administrador en este proyecto, no puede realizar cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Crear una lista para almacenar los integrantes
                listaIntegrantes = new List<Integrante>();
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewEmpleados.SelectedRows[0];

                // Obtener el objeto Integrante correspondiente a la fila seleccionada
                Integrante integranteSeleccionado = (Integrante)filaSeleccionada.DataBoundItem;

                // Obtener la lista de Integrantes del DataSource del DataGridView
                listaIntegrantes = (List<Integrante>)dataGridViewEmpleados.DataSource;

                // Eliminar el objeto Integrante de la lista
                listaIntegrantes.Remove(integranteSeleccionado);
                dataGridViewEmpleados.DataSource = null;
                // Actualizar el DataGridView (esto es necesario si el DataGridView no se actualiza automáticamente)
                CargarEmpleados(listaIntegrantes);
            }
        }

        List<PEDIDOxPROYECTO> listaPedidos;
        private void CargarPEDIDOSxPROYECTO(List<PEDIDOxPROYECTO> listaPedidos)
        {
            dataGridViewPedidos.DataSource = listaPedidos;
            dataGridViewPedidos.Columns["ID_Proyecto"].Visible = false;
            dataGridViewPedidos.Columns["ID_Pedido"].Visible = true;
        }
        private void buttonVerPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                // Logica para abrir FormDetallePedido usando el ID del pedido seleccionado
                int idPedido = ((PEDIDOxPROYECTO)dataGridViewPedidos.SelectedRows[0].DataBoundItem).ID_Pedido;
                using (FormDetallesPedido formulario = FormDetallesPedido.ObtenerInstancia(idPedido, 0))
                {
                    formulario.ShowDialog();
                }
            }
        }

        private void buttonAgregarPedido_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show("Usted no tiene el cargo Administrador en este proyecto, no puede realizar cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Logica para agregar un PEDIDOxPROYECTO al dataGridViewPedidos
            FormGestionarPedidos form = FormGestionarPedidos.GetInstance();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Pedido pedidoSeleccionado = form.pedidoSeleccionado;
                if (listaPedidos == null)
                {
                    listaPedidos = new List<PEDIDOxPROYECTO>();
                }
                if (pedidoSeleccionado != null && !listaPedidos.Any(i => i.ID_Pedido == pedidoSeleccionado.ID_Pedido))
                {
                    PEDIDOxPROYECTO nuevoPedido = new PEDIDOxPROYECTO
                    {
                        ID_Pedido = pedidoSeleccionado.ID_Pedido,
                        ID_Proyecto = string.IsNullOrWhiteSpace(textBoxNumero.Text) ? 0 : int.Parse(textBoxNumero.Text)
                    };
                    listaPedidos.Add(nuevoPedido);
                    dataGridViewPedidos.DataSource = null;
                    CargarPEDIDOSxPROYECTO(listaPedidos);
                }
            }
        }

        private void buttonEliminarPedido_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show("Usted no tiene el cargo Administrador en este proyecto, no puede realizar cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridViewPedidos.SelectedRows.Count > 0)
            {
                // Obtener el objeto PEDIDOxPROYECTO correspondiente a la fila seleccionada
                PEDIDOxPROYECTO pedidoSeleccionado = (PEDIDOxPROYECTO)dataGridViewPedidos.SelectedRows[0].DataBoundItem;

                // Eliminar el pedido de la lista
                listaPedidos.Remove(pedidoSeleccionado);
                dataGridViewPedidos.DataSource = null;
                // Actualizar el DataGridView (esto es necesario si el DataGridView no se actualiza automáticamente)
                CargarPEDIDOSxPROYECTO(listaPedidos);
            }
        }
        private void GuardarPEDIDOSxPROYECTO()
        {
            List<PEDIDOxPROYECTO> listaNuevaPedidos = new List<PEDIDOxPROYECTO>();
            foreach (DataGridViewRow row in dataGridViewPedidos.Rows)
            {
                if (!row.IsNewRow)
                {
                    PEDIDOxPROYECTO integrante = (PEDIDOxPROYECTO)row.DataBoundItem;
                    listaNuevaPedidos.Add(integrante);
                }
            }
            int resultado = CN_Proyectos.ObtenerInstancia().ModificarPEDIDOxPROYECTO(listaNuevaPedidos, esteProyecto.ID_Proyecto);
        }
    }
}
