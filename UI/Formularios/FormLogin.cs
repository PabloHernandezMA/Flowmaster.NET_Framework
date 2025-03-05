using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Dominio.Clases;
using Modelo;

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
                if (ValidacionesForm.NoEstaVacio(textBoxPassword.Text))
                {
                    CN_UsuarioEnSesion usuarioEnSesion = CN_UsuarioEnSesion.ObtenerInstancia();
                    var validUser = usuarioEnSesion.LoginUser(textBoxUsername.Text, textBoxPassword.Text);
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

        // Diccionario para almacenar temporalmente los códigos de restablecimiento
        private Dictionary<string, string> codigosRestablecimiento = new Dictionary<string, string>();

        private void linkLabelRestablecerContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ValidacionesForm.NoEstaVacio(textBoxUsername.Text))
            {
                List<Usuario> usuarios = CN_Usuarios.ObtenerInstancia().ObtenerTodosLosUsuarios();

                // Buscar usuario por nombre de usuario o email
                Usuario usuario = usuarios.FirstOrDefault(u => u.Username == textBoxUsername.Text || u.User_Email == textBoxUsername.Text);

                if (usuario != null)
                {
                    // Generar un código de restablecimiento (hash de la fecha y hora actual)
                    string codigoRestablecimiento = GenerarCodigoRestablecimiento();

                    // Almacenar el código en el diccionario usando el email/username como clave
                    codigosRestablecimiento[usuario.User_Email] = codigoRestablecimiento;
                    codigosRestablecimiento[usuario.Username] = codigoRestablecimiento;

                    // Enviar email con el código
                    EnviarCorreo(usuario.User_Email, "Código de Restablecimiento", $"Tu código de restablecimiento es: {codigoRestablecimiento}");

                    MessageBox.Show("Se ha enviado un código de restablecimiento a tu correo electrónico.");

                    // Habilitar los campos para ingresar el código y la nueva contraseña
                    buttonIniciarSesion.Visible = false;
                    textBoxCodigo.Visible = true;
                    labelCodigo.Visible = true;
                    labelPassword.Text = "Nueva Contraseña";
                    buttonCambiarPassword.Visible = true;
                }
                else
                {
                    msgError("El usuario o email no existe.");
                }
            }
            else
            {
                msgError("Por favor ingrese nombre de usuario o email.");
                textBoxUsername.Focus();
            }
        }

        // Función para generar código de restablecimiento
        private string GenerarCodigoRestablecimiento()
        {
            return DateTime.Now.Ticks.ToString("X").Substring(8); // Extrae una parte del hash para hacerlo más corto
        }

        // Función para enviar correo (debes configurarlo con tus credenciales SMTP)
        private void EnviarCorreo(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.From = new MailAddress("flowmasteremail@gmail.com");
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Credentials = new System.Net.NetworkCredential("flowmasteremail@gmail.com", "vply anbf xqip zbrz");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        // Evento para confirmar el restablecimiento de contraseña
        private void buttonCambiarPassword_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = textBoxUsername.Text;
            string codigoIngresado = textBoxCodigo.Text;
            string nuevaContraseña = textBoxPassword.Text;

            // Validar que se haya ingresado el código y la nueva contraseña
            if (ValidacionesForm.NoEstaVacio(codigoIngresado) && ValidacionesForm.NoEstaVacio(nuevaContraseña))
            {
                // Verificar si el código ingresado coincide con el almacenado
                if (codigosRestablecimiento.ContainsKey(usernameOrEmail) && codigosRestablecimiento[usernameOrEmail] == codigoIngresado)
                {
                    // Restablecer la contraseña en la base de datos
                    CN_Usuarios.ObtenerInstancia().RestablecerContraseña(usernameOrEmail, usernameOrEmail, nuevaContraseña);

                    MessageBox.Show("Contraseña restablecida con éxito.");

                    // Limpiar campos y deshabilitar controles
                    textBoxCodigo.Text = "";
                    //textBoxPassword.Text = "";
                    textBoxCodigo.Visible = false;
                    labelCodigo.Visible = false;
                    buttonCambiarPassword.Visible = false;
                    buttonIniciarSesion.Visible = true;
                    labelPassword.Text = "Contraseña";

                    // Eliminar el código de la lista para seguridad
                    codigosRestablecimiento.Remove(usernameOrEmail);
                }
                else
                {
                    msgError("Código incorrecto. Verifica el código enviado a tu email.");
                }
            }
            else
            {
                msgError("Por favor ingrese el código y la nueva contraseña.");
            }
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
        }
    }
}
