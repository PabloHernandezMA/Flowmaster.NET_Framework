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
        private static FormGestionarProyectos instance;
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
            using (FormProyecto formulario = FormProyecto.GetInstance())
            {
                formulario.ShowDialog();
            }
        }
    }
}
