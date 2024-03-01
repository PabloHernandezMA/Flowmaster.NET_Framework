using Dominio;
using Dominio.Clases;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Administracion.Usuarios.Gestionar_Usuarios
{
    public partial class FormDetallesUsuario : Form
    {
        private CN_Grupos grupos;
        private CN_Usuarios usuario;
        private int idUsuario;

        public FormDetallesUsuario(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void FormDetallesUsuario_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            usuario = CN_Usuarios.ObtenerInstancia();
            try
            {
                Usuario usuarioData = usuario.ObtenerUsuarioPorID(idUsuario);
                if (usuario != null)
                {
                    textBoxNombre.Text = usuarioData.Username;
                    textBoxContrasena.Text = usuarioData.User_Password;
                    textBoxEmail.Text = usuarioData.User_Email;
                    checkBoxHabilitado.Checked = usuarioData.is_Enabled;
                    labelNumeroID.Text = usuarioData.ID_User.ToString();
                }
                else
                {
                    MessageBox.Show("El usuario no fue encontrado.");
                    this.Close(); // Cierra el formulario si no se encuentra el usuario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message);
               // this.Close(); // Cierra el formulario en caso de error
            }
            CargarGrupos();
        }

        private void CargarGrupos()
        {
            grupos = CN_Grupos.ObtenerInstancia();
            try
            {
                dataGridViewGruposDisponibles.DataSource = grupos.ObtenerGruposNoAsociadosAUsuario(idUsuario);
                dataGridViewGruposMiembro.DataSource = grupos.ObtenerGruposPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
