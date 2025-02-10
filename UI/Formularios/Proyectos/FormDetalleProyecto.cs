using Dominio.Aplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Formularios.Administracion.Empleados;
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
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
            }
            else
            {
                // Modificación de proyecto existente
                filasAfectadas = CN_Proyectos.ObtenerInstancia().ModificarProyecto(proyecto);
                GuardarEmpleados();
            }

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
            int resultado = CN_Proyectos.ObtenerInstancia().ModificarEmpleadosxProyecto(listaIntegrantes);        
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

            if (dateTimePickerInicio.Value >= dateTimePickerFin.Value)
            {
                errorProvider1.SetError(dateTimePickerFin, "La fecha de fin debe ser posterior a la de inicio.");
                esValido = false;
            }

            return esValido;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            FormGestionarEmpleados form = FormGestionarEmpleados.ObtenerInstancia(1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Empleado empleadoSeleccionado = form.EmpleadoSeleccionado;
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

                // Actualizar el DataGridView (esto es necesario si el DataGridView no se actualiza automáticamente)
                CargarEmpleados(listaIntegrantes);
            }
        }
    }
}
