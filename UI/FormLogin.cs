using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (textBoxUsername.Text!="")
            {
                if(textBoxPassword.Text!="")
                { 
                    FormMainMenu MainMenu = new FormMainMenu();
                    MainMenu.Show();
                    MainMenu.FormClosed += CerrarSesion;
                    this.Hide();
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
    }
}
