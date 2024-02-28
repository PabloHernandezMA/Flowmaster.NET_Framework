using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Dominio.Modelos;

namespace UI.Administracion.Usuarios.Gestionar_Usuarios
{
    public partial class FormGestionarUsuarios : Form
    {
        private ModelUsuarios usuarios = new ModelUsuarios();
        private CN_Usuarios cnUsuarios;

        public FormGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario pop-up
            FormDetallesUsuario formPopup = new FormDetallesUsuario();

            // Mostrar el formulario como un cuadro de diálogo modal
            formPopup.ShowDialog();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            listarUsuarios();
            /*
            cnUsuarios = new CN_Usuarios();
            dataGridView1.DataSource = cnUsuarios.MostrarUsuarios();
            */
        }

        private void listarUsuarios()
        {
            try
            {
                dataGridView1.DataSource = usuarios.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
