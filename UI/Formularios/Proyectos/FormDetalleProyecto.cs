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
        private int idSeleccion;

        public FormDetalleProyecto(int idSeleccion)
        {
            this.idSeleccion = idSeleccion;
        }

        private FormDetalleProyecto()
        {
            InitializeComponent();
        }
        public static FormDetalleProyecto ObtenerInstancia(int idSeleccion)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormDetalleProyecto(idSeleccion);
            }
            return instance;
        }

        private void FormDetalleProyecto_Load(object sender, EventArgs e)
        {
            
        }
    }
}
