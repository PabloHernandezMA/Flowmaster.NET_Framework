using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Administracion;
using UI.Configuracion;

namespace UI
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void buttonCerrarAplicacion_Click(object sender, EventArgs e)
        {
            // Mostrar un MessageBox preguntando al usuario si desea cerrar la aplicación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la aplicación?", "Flowmaster", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                // Cerrar la aplicación si el usuario ha confirmado
                Application.Exit();
            }
        }

        private void buttonMaximizarAplicacion_Click(object sender, EventArgs e)
        {
            // Maximizar o restaurar el tamaño del formulario
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void buttonMinimizarAplicacion_Click(object sender, EventArgs e)
        {
            // Minimizar el formulario
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            // Mostrar un MessageBox preguntando al usuario si desea cerrar la aplicación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Flowmaster", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                // Cerrar la aplicación si el usuario ha confirmado
                this.Close();
            }
        }

        private void buttonFlowmaster_Click(object sender, EventArgs e)
        {

        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {

        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {

        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdministracion_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que deseas mostrar
            FormAdministracion formAdmin = new FormAdministracion();

            // Configurar la forma para que pueda ser incrustada
            formAdmin.TopLevel = false;
            formAdmin.FormBorderStyle = FormBorderStyle.None;
            formAdmin.Dock = DockStyle.Fill;

            // Agregar el formulario al PanelCenter
            panelCenter.Controls.Clear(); // Limpiar cualquier control existente en el PanelCenter
            panelCenter.Controls.Add(formAdmin); // Agregar el formulario al PanelCenter
            formAdmin.Show(); // Mostrar el formulario
        }

        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que deseas mostrar
            FormConfiguracion formAdmin = new FormConfiguracion();

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
