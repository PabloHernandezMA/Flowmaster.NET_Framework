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

namespace UI.Formularios.Proyectos
{
    public partial class FormProyecto : Form
    {
        private CN_Proyectos proyecto;
        private Proyecto proyectoSeleccionado;
        private static FormProyecto instance;
        private int idProyectoSeleccionado;
        private CN_Columnas columnas;
        private FormProyecto()
        {
            InitializeComponent();
        }
        private FormProyecto(int idProyecto)
        {
            InitializeComponent();
            this.idProyectoSeleccionado = idProyecto;
        }
        public static FormProyecto ObtenerInstancia(int idProyecto)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormProyecto(idProyecto);
            }
            return instance;
        }

        private void FormProyecto_Load(object sender, EventArgs e)
        {
            proyectoSeleccionado = CN_Proyectos.ObtenerInstancia().ObtenerProyecto(idProyectoSeleccionado);
            labelProyecto.Text = $"Proyecto: {proyectoSeleccionado.ID_Proyecto}";
            textBoxNombreProyecto.Text = proyectoSeleccionado.Nombre;
            dateTimePickerFechaFinProyecto.Text = proyectoSeleccionado.FechaFin.ToShortDateString();
            comboBoxEstadoProyecto.Text = proyectoSeleccionado.Estado.ToString();
            cargarColumnas(proyectoSeleccionado.ID_Proyecto);
        }
        private void cargarColumnas(int idProyecto)
        {
            columnas = CN_Columnas.ObtenerInstancia();
            List<Columna> columnasDelProyecto = columnas.ObtenerTodasLasColumnasDelProyecto(idProyecto);
            Button buttonAgregarColumna = this.buttonAgregarColumna;
            flowLayoutPanelTablero.Controls.Clear();

            foreach (Columna columna in columnasDelProyecto)
            {
                UserControlColumna userControlColumna = new UserControlColumna();
                userControlColumna.ConfigurarColumna(columna);
                flowLayoutPanelTablero.Controls.Add(userControlColumna);
            }
            flowLayoutPanelTablero.Controls.Add(buttonAgregarColumna);
        }

        private void buttonAgregarColumna_Click(object sender, EventArgs e)
        {

        }
    }
}
