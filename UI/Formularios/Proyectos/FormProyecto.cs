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
        private CN_Proyectos proyectos;
        private Proyecto esteProyecto;
        private static FormProyecto instance;
        private CN_Columnas columnas;
        private FormProyecto()
        {
            InitializeComponent();
        }
        private FormProyecto(Proyecto proyecto)
        {
            InitializeComponent();
            esteProyecto = proyecto;
            proyectos = CN_Proyectos.ObtenerInstancia();
        }
        public static FormProyecto ObtenerInstancia(Proyecto proyectoSeleccionado)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormProyecto(proyectoSeleccionado);
            }
            return instance;
        }

        private void FormProyecto_Load(object sender, EventArgs e)
        {
            cargarDatosProyecto();
            cargarColumnas(esteProyecto.ID_Proyecto);
        }
        private void cargarDatosProyecto()
        {
            this.Text = $"Proyecto: {esteProyecto.Nombre}";
            labelProyecto.Text = $"Proyecto: {esteProyecto.ID_Proyecto}";
            textBoxNombreProyecto.Text = esteProyecto.Nombre;
            dateTimePickerFechaFinProyecto.Text = esteProyecto.FechaFin.ToShortDateString();
            comboBoxEstadoProyecto.Text = esteProyecto.Estado.ToString();
            
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

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            using (FormDetalleProyecto formulario = FormDetalleProyecto.ObtenerInstancia(esteProyecto))
            {
                formulario.ShowDialog();
            }
            esteProyecto = proyectos.ObtenerProyecto(esteProyecto.ID_Proyecto);
            cargarDatosProyecto();
        }
    }
}
