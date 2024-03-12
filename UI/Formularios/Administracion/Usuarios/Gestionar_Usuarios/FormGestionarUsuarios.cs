using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Dominio.Clases;
using Modelo;

namespace UI.Administracion.Usuarios.Gestionar_Usuarios
{
    public partial class FormGestionarUsuarios : Form
    {
        private CN_Usuarios usuarios;
        private CN_UsuarioEnSesion usuarioEnSesion;
        public FormGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idUsuarioSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_User"].Value);

                // Usando el bloque using, se asegura de que la instancia del formulario se libere correctamente
                using (FormDetallesUsuario formDetallesUsuario = new FormDetallesUsuario(idUsuarioSeleccionado))
                {
                    formDetallesUsuario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario primero.");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxNumero.Text = "";
            textBoxEmail.Text = "";
            checkBoxSoloHabilitados.Checked = false;
            listarUsuarios();
        }

        private void listarUsuarios()
        {         
            try
            {
                dataGridView1.DataSource = usuarios.ObtenerTodosLosUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FiltrarDatos(object sender, EventArgs e)
        {
            dataGridView1.DataSource = usuarios.Filtrar(textBoxNombre.Text, textBoxNumero.Text, textBoxEmail.Text, checkBoxSoloHabilitados.Checked);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Obtener la columna en la que se hizo clic
            DataGridViewColumn columna = dataGridView1.Columns[e.ColumnIndex];

            // Obtener los datos del DataGridView
            List<Usuario> usuarios = dataGridView1.DataSource as List<Usuario>;

            // Verificar si la columna es válida y si hay datos
            if (columna != null && usuarios != null && usuarios.Any())
            {
                // Ordenar los datos según la columna en la que se hizo clic
                switch (columna.DataPropertyName)
                {
                    case "Username":
                        usuarios = usuarios.OrderBy(u => u.Username).ToList();
                        break;
                    case "ID_User":
                        usuarios = usuarios.OrderBy(u => u.ID_User).ToList();
                        break;
                    case "User_Email":
                        usuarios = usuarios.OrderBy(u => u.User_Email).ToList();
                        break;
                    case "is_Enabled":
                        usuarios = usuarios.OrderBy(u => u.is_Enabled).ToList();
                        break;
                }
                // Actualizar el origen de datos del DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = usuarios;
            }
        }

        private void FormGestionarUsuarios_Load(object sender, EventArgs e)
        {
            // Suscribir eventos para los controles
            textBoxNombre.TextChanged += FiltrarDatos;
            textBoxNumero.TextChanged += FiltrarDatos;
            textBoxEmail.TextChanged += FiltrarDatos;
            checkBoxSoloHabilitados.CheckedChanged += FiltrarDatos;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            usuarios = CN_Usuarios.ObtenerInstancia();
            VerificarPermisos();
        }

        private void VerificarPermisos()
        {
            usuarioEnSesion = CN_UsuarioEnSesion.ObtenerInstancia();
            if (!usuarioEnSesion.VerificarPermiso(98))
            {
                buttonBuscar.Enabled = false;
            }
            if (!usuarioEnSesion.VerificarPermiso(99))
            {
                buttonVerDetalles.Enabled = false;
            }
            if (!usuarioEnSesion.VerificarPermiso(100))
            {
                buttonAgregar.Enabled = false;
            }
            if (!usuarioEnSesion.VerificarPermiso(101))
            {
                buttonEliminar.Enabled = false;
            }
            if (!usuarioEnSesion.VerificarPermiso(102))
            {
                buttonModificar.Enabled = false;
            }
        }
    }
}
