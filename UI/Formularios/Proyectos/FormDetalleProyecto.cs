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
    public partial class FormDetalleProyecto : Form
    {
        private static FormDetalleProyecto instance;
        private Proyecto esteProyecto;
        public FormDetalleProyecto(Proyecto proyecto)
        {
            esteProyecto = proyecto;
            textBoxNumero.Text = proyecto.ID_Proyecto.ToString();
            textBoxNombre.Text = proyecto.Nombre;
            comboBoxEstadoProyecto.Text = proyecto.Estado.ToString();

        }

        private FormDetalleProyecto()
        {
            InitializeComponent();
        }
        public static FormDetalleProyecto ObtenerInstancia()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormDetalleProyecto();
            }
            return instance;
        }
        public static FormDetalleProyecto ObtenerInstancia(Proyecto proyecto)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormDetalleProyecto(proyecto);
            }
            return instance;
        }

        private void FormDetalleProyecto_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
