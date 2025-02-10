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
        private void CargarComboBoxEmpleados() {
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
            labelEmpleado.Text = comboBoxEmpleado.SelectedValue.ToString();
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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaFiltrada;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            using (FormDetalleProyecto formulario = FormDetalleProyecto.ObtenerInstancia())
            {
                formulario.ShowDialog();
            }
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
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proyecto.");
            }
        }
    }
}
