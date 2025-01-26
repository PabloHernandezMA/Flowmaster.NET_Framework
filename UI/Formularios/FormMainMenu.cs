using Dominio;
using Dominio.Seguridad;
using Modelo;
using Modelo.Seguridad;
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
using UI.Formularios.Dashboard;
using UI.Formularios.Pedidos;
using UI.Productos;
using UI.Formularios.Proyectos;

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

        private Form currentForm; // Variable para almacenar el formulario actualmente abierto

        private void AbrirFormulario(Form formulario)
        {
            // Verificar si el formulario que se intenta abrir es el mismo que el actualmente abierto
            if (currentForm == formulario)
            {
                return; // No hacer nada si es el mismo formulario
            }

            // Cerrar y liberar la instancia del formulario anterior, si existe
            if (currentForm != null && !currentForm.IsDisposed)
            {
                currentForm.Dispose();
            }

            // Configurar el nuevo formulario para que pueda ser incrustado
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Limpiar cualquier control existente en el PanelCenter y agregar el nuevo formulario
            panelCenter.Controls.Clear();
            panelCenter.Controls.Add(formulario);

            // Mostrar el nuevo formulario
            formulario.Show();

            // Actualizar la instancia del formulario actual
            currentForm = formulario;
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            // Mostrar un MessageBox preguntando al usuario si desea cerrar la aplicación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Flowmaster", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                AuditarCierreSesion();
                // Cerrar la aplicación si el usuario ha confirmado
                this.Close();
            }
        }

        private void buttonFlowmaster_Click(object sender, EventArgs e)
        {
            // Cerrar cualquier formulario abierto en el panelCenter
            if (panelCenter.Controls.Count > 0)
            {
                panelCenter.Controls[0].Dispose();
            }
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            // Aquí llamamos al método GetInstance() en lugar de crear una nueva instancia
            FormDashboard formAdmin = FormDashboard.GetInstance();
            AbrirFormulario(formAdmin);
        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {
            // Aquí llamamos al método GetInstance() en lugar de crear una nueva instancia
            FormGestionarPedidos formAdmin = FormGestionarPedidos.GetInstance();
            AbrirFormulario(formAdmin);
        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {
            // Aquí llamamos al método GetInstance() en lugar de crear una nueva instancia
            FormGestionarProductos formAdmin = FormGestionarProductos.GetInstance();
            AbrirFormulario(formAdmin);
        }

        private void buttonAdministracion_Click(object sender, EventArgs e)
        {
            // Aquí llamamos al método GetInstance() en lugar de crear una nueva instancia
            FormAdministracion formAdmin = FormAdministracion.GetInstance();
            AbrirFormulario(formAdmin);
        }

        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            // Aquí llamamos al método GetInstance() en lugar de crear una nueva instancia
            FormConfiguracion formAdmin = FormConfiguracion.GetInstance();
            AbrirFormulario(formAdmin);
        }

        private void buttonProyectos_Click(object sender, EventArgs e)
        {
            FormGestionarProyectos formAdmin = FormGestionarProyectos.GetInstance();
            AbrirFormulario(formAdmin);
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            Usuario usuarioEnSesion = CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario();
            labelUsername.Text = usuarioEnSesion.Username;
        }

        private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuditarCierreSesion();
        }

        private void AuditarCierreSesion()
        {
            AuditoriaSesiones auditoria = new AuditoriaSesiones
            {
                ID_User = CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User,
                Username = CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().Username,
                TipoOperacion = 2,
                FechaHora = DateTime.Now
            };
            CN_AuditoriaSesiones.ObtenerInstancia().RegistrarAuditoria(auditoria);
        }
    }
}
