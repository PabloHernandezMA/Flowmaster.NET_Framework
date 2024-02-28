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
using UI.Configuracion.Base_De_Datos;

namespace UI.Configuracion
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void gestionarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que deseas mostrar
            FormBaseDeDatos formAdmin = new FormBaseDeDatos();

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
