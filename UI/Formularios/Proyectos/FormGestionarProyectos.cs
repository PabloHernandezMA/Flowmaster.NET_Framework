using Dominio;
using Dominio.Aplicacion;
using Modelo;
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
using UI.Formularios.Pedidos;

namespace UI.Formularios.Proyectos
{
    public partial class FormGestionarProyectos : Form
    {
        private int Buscar_proyectos = 111;
        private int Ver_proyecto = 112;
        private int Agregar_proyecto = 113;
        private int Borrar_proyecto = 114;
        private int Editar_proyecto = 115;

        private CN_Proyectos proyectos;
        private static FormGestionarProyectos instance;
        private List<Proyecto> ListaDeProyectos; // Lista completa de proyectos
        private List<Proyecto> listaFiltrada; // Lista filtrada
        private FormGestionarProyectos()
        {
            InitializeComponent();
        }
        public static FormGestionarProyectos GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarProyectos();
            }
            return instance;
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Proyecto ObjSeleccionado = (Proyecto)dataGridView1.SelectedRows[0].DataBoundItem;
                using (FormProyecto formulario = FormProyecto.ObtenerInstancia(ObjSeleccionado))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proyecto.");
            }
        }

        private void FormGestionarProyectos_Load(object sender, EventArgs e)
        {
            InicializarEventos();
            CargarPermisos();
        }
        private void CargarPermisos()
        {
            buttonBuscar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Buscar_proyectos);
            buttonVerDetalles.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Ver_proyecto);
            buttonAgregar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Agregar_proyecto);
            buttonEliminar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Borrar_proyecto);
            buttonModificar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Editar_proyecto);

        }
        private void InicializarEventos()
        {
            proyectos = CN_Proyectos.ObtenerInstancia();
            CargarComboBoxEmpleados();
            textBoxNumero.TextChanged += (s, e) => FiltrarResultados();
            comboBoxEstadoProyecto.SelectedIndexChanged += (s, e) => FiltrarResultados();
            dateTimePickerFechaInicio.ValueChanged += (s, e) => FiltrarResultados();
            comboBoxEmpleado.SelectedValueChanged += (s, e) => FiltrarResultados();
        }
        private void CargarComboBoxEmpleados()
        {
            List<Empleado> empleados = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            var empleadosHabilitados = empleados.Where(e => e.Habilitado).ToList();
            comboBoxEmpleado.DataSource = empleadosHabilitados;
            comboBoxEmpleado.ValueMember = "ID_Empleado";
            comboBoxEmpleado.DisplayMember = "Nombre";
            comboBoxEmpleado.Text = "Todos";
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarProyectos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CargarProyectos()
        {
            ListaDeProyectos = proyectos.ObtenerTodosLosProyectos();
            listaFiltrada = new List<Proyecto>(ListaDeProyectos);
            ActualizarDataGridView();
        }

        private void FiltrarResultados()
        {
            CargarProyectos();
            // Filtrado usando LINQ
            if (comboBoxEmpleado.Enabled == false)
            {
                // Significa que se deben mostrar los proyectos que cumplen con otros parametros de filtrado ya que se buscan Todos los empleados
                listaFiltrada = ListaDeProyectos.Where(p =>
        (string.IsNullOrEmpty(textBoxNumero.Text) || p.ID_Proyecto.ToString().Contains(textBoxNumero.Text)) &&
        (comboBoxEstadoProyecto.SelectedItem == null || comboBoxEstadoProyecto.SelectedItem.ToString() == "Todos" || p.Estado == comboBoxEstadoProyecto.SelectedItem.ToString()) &&
        (dateTimePickerFechaInicio.Checked == false || p.FechaInicio.Date >= dateTimePickerFechaInicio.Value.Date)
    ).ToList();

            }
            else
            {
                // se deberá buscar tambien por los empleados que participan en un proyecto.
                listaFiltrada = proyectos.ObtenerTodosLosProyectosEnLosQueParticipaUnEmpleado((int)comboBoxEmpleado.SelectedValue);
                listaFiltrada = listaFiltrada.Where(p =>
    (string.IsNullOrEmpty(textBoxNumero.Text) || p.ID_Proyecto.ToString().Contains(textBoxNumero.Text)) &&
    (comboBoxEstadoProyecto.SelectedItem == null || comboBoxEstadoProyecto.SelectedItem.ToString() == "Todos" || p.Estado == comboBoxEstadoProyecto.SelectedItem.ToString()) &&
    (dateTimePickerFechaInicio.Checked == false || p.FechaInicio.Date >= dateTimePickerFechaInicio.Value.Date)
).ToList();
            }

            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            buttonModificar.Enabled = false;
            buttonEliminar.Enabled = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaFiltrada;
            // Ocultar columnas no deseadas
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = false; // Ocultar todas las columnas inicialmente
            }

            // Mostrar solo las columnas deseadas
            dataGridView1.Columns["Nombre"].Visible = true;
            dataGridView1.Columns["FechaInicio"].Visible = true;
            dataGridView1.Columns["FechaFin"].Visible = true;
            dataGridView1.Columns["Estado"].Visible = true;

            // Ajustar el tamaño de las columnas
            dataGridView1.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["FechaInicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["FechaFin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            using (FormDetalleProyecto formulario = FormDetalleProyecto.ObtenerInstancia())
            {
                formulario.ShowDialog();
            }
            CargarProyectos();
        }

        private void checkBoxEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEmpleado.Checked) { comboBoxEmpleado.Enabled = true; }
            else { comboBoxEmpleado.Enabled = false; comboBoxEmpleado.Text = "Todos"; }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Proyecto ObjSeleccionado = (Proyecto)dataGridView1.SelectedRows[0].DataBoundItem;
                using (FormDetalleProyecto formulario = FormDetalleProyecto.ObtenerInstancia(ObjSeleccionado))
                {
                    formulario.ShowDialog();
                }
                CargarProyectos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proyecto.");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Proyecto ObjSeleccionado = (Proyecto)dataGridView1.SelectedRows[0].DataBoundItem;
                DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el proyecto {ObjSeleccionado.Nombre} y sus dependencias?",
                "Eliminar proyecto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    CN_Proyectos.ObtenerInstancia().BajaProyecto(ObjSeleccionado.ID_Proyecto);
                    MessageBox.Show("Operación completada.");
                    CargarProyectos();
                }
                else
                {
                    MessageBox.Show("Operación cancelada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proyecto.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Proyecto ObjSeleccionado = (Proyecto)dataGridView1.SelectedRows[0].DataBoundItem;

            int idEmpleadoActual = CN_Empleados.ObtenerInstancia()
                .ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User)
                .ID_Empleado;

            // Obtener la lista de integrantes del proyecto seleccionado
            List<Integrante> integrantes = proyectos.ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(ObjSeleccionado.ID_Proyecto);

            // Verificar si el empleado actual está en la lista de integrantes
            if (integrantes.Any(i => i.ID_Empleado == idEmpleadoActual && i.Cargo == "Administrador"))
            {
                buttonEliminar.Enabled = true;
                buttonModificar.Enabled = true;
                buttonEliminar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Borrar_proyecto);
                buttonModificar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(Editar_proyecto);
            }
            else
            {
                buttonEliminar.Enabled = false;
                buttonModificar.Enabled = false;
            }
        }
    }
}
