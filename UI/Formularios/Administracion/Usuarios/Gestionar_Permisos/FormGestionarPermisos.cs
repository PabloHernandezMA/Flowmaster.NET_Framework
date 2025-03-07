using Dominio;
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

namespace UI.Formularios.Administracion.Usuarios.Gestionar_Permisos
{
    public partial class FormGestionarPermisos : Form
    {
        public FormGestionarPermisos()
        {
            InitializeComponent();
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            // Usando el bloque using, se asegura de que la instancia del formulario se libere correctamente
            using (FormDetallesPermiso FormDetallesPermiso = new FormDetallesPermiso())
            {
                FormDetallesPermiso.ShowDialog();
            }
        }

        private void FormGestionarPermisos_Load(object sender, EventArgs e)
        {
            buttonVerPermisos.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(109);
            buttonModificar.Enabled = CN_UsuarioEnSesion.ObtenerInstancia().VerificarPermiso(110);
        }
    }
}
