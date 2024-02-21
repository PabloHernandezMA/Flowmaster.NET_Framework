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
    public partial class FormGestionarUsuarios : Form
    {
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
    }
}
