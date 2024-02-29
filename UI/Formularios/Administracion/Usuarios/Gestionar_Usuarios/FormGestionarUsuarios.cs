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

namespace UI.Administracion.Usuarios.Gestionar_Usuarios
{
    public partial class FormGestionarUsuarios : Form
    {
        private CN_Usuarios usuarios;

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

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = usuarios.Filtrar(textBoxNombre.Text);
        }

        private void FormGestionarUsuarios_Load(object sender, EventArgs e)
        {
            usuarios = CN_Usuarios.ObtenerInstancia();
        }
    }
}
