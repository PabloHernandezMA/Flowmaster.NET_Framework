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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
