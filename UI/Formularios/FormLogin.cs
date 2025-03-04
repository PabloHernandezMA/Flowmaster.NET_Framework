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

namespace UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            textBoxUsername.Focus();
            labelErrorMessage.Visible = false;
        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            if (ValidacionesForm.NoEstaVacio(textBoxUsername.Text))
            {
                if(ValidacionesForm.NoEstaVacio(textBoxPassword.Text))
                {
                    CN_UsuarioEnSesion usuarioEnSesion = CN_UsuarioEnSesion.ObtenerInstancia();
                    var validUser = usuarioEnSesion.LoginUser(textBoxUsername.Text,textBoxPassword.Text);
                    if (validUser)
                    {
                        FormMainMenu MainMenu = new FormMainMenu();
                        MainMenu.Show();
                        MainMenu.FormClosed += CerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        msgError("El usuario o contraseña no son válidos");
                        textBoxPassword.Clear();
                        textBoxPassword.Focus();
                    }
                }
                else
                {
                msgError("Por favor ingrese una contraseña");
                textBoxPassword.Focus();
                }
            } else
            {
                msgError("Por favor ingrese nombre de usuario o email");
                textBoxUsername.Focus();
            }
        }

        private void msgError(string msg)
        { 
            labelErrorMessage.Text = "     " + msg;
            labelErrorMessage.Visible = true;
        }

        private void CerrarSesion(object sender, FormClosedEventArgs e)
        {

            textBoxUsername.Clear();
            textBoxPassword.Clear();
            labelErrorMessage.Visible = false;
            this.Show();
            textBoxUsername.Focus();
        }

        private void linkLabelRestablecerContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ValidacionesForm.NoEstaVacio(textBoxUsername.Text))
            {
                MessageBox.Show("Se enviarán instrucciones para restablecer la contraseña al email as", "Flowmaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Se ha enviado un email a la dirección proporcionada con las instrucciones para restablecer la contraseña", "Flowmaster", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                msgError("Por favor ingrese nombre de usuario o email");
                textBoxUsername.Focus();
            }
        }
    }
}
