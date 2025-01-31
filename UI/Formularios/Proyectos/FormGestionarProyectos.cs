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
            proyectos = CN_Proyectos.ObtenerInstancia();
            InicializarEventos();
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
        private void InicializarEventos()
        {
            textBoxNumero.TextChanged += (s, e) => FiltrarResultados();
            comboBoxEstadoProyecto.SelectedIndexChanged += (s, e) => FiltrarResultados();
            dateTimePickerFechaInicio.ValueChanged += (s, e) => FiltrarResultados();
        }
        private void FiltrarResultados()
        {
            CargarProyectos();
            // Filtrado usando LINQ
            listaFiltrada = ListaDeProyectos.Where(p =>
                (string.IsNullOrEmpty(textBoxNumero.Text) || p.ID_Proyecto.ToString().Contains(textBoxNumero.Text)) &&
                (comboBoxEstadoProyecto.SelectedIndex == -1 || p.Estado == comboBoxEstadoProyecto.SelectedItem.ToString()) &&
                (dateTimePickerFechaInicio.Checked == false || p.FechaInicio.Date >= dateTimePickerFechaInicio.Value.Date)
            ).ToList();

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
    }
}
