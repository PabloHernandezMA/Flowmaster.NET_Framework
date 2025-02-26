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
using UI.Formularios.Configuracion;

namespace UI.Configuracion
{
    public partial class FormConfiguracion : Form
    {
        private static FormConfiguracion instance;

        private FormConfiguracion()
        {
            InitializeComponent();
        }

        public static FormConfiguracion GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormConfiguracion();
            }
            return instance;
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

        private void órdenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario AboutBoxFlowmaster
            AboutBoxFlowmaster aboutBox = new AboutBoxFlowmaster();

            // Mostrar el formulario como un pop-up
            aboutBox.ShowDialog();
        }
    }
}
