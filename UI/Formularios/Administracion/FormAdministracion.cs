using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Administracion.Usuarios.Gestionar_Usuarios;

namespace UI.Administracion
{
    public partial class FormAdministracion : Form
    {
        public FormAdministracion()
        {
            InitializeComponent();
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que deseas mostrar
            FormGestionarUsuarios formAdmin = new FormGestionarUsuarios();

            // Configurar la forma para que pueda ser incrustada
            formAdmin.TopLevel = false;
            formAdmin.FormBorderStyle = FormBorderStyle.None;
            formAdmin.Dock = DockStyle.Fill;

            // Agregar el formulario al PanelCenter
            panelCenter.Controls.Clear(); // Limpiar cualquier control existente en el PanelCenter
            panelCenter.Controls.Add(formAdmin); // Agregar el formulario al PanelCenter
            formAdmin.Show(); // Mostrar el formulario
        }
    }
}
