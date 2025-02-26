using Dominio.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Configuracion.Base_De_Datos
{
    public partial class FormBaseDeDatos : Form
    {
        private ClassDataBase db;

        public FormBaseDeDatos()
        {
            InitializeComponent();
            db = ClassDataBase.ObtenerInstancia();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string server = textBoxServidor.Text;
            string database = textBoxNombreDB.Text;
            string username = textBoxUsuario.Text;
            string password = textBoxContraseña.Text;

            string jsonConfig = $"{{ \"Server\": \"{server}\", \"Database\": \"{database}\", \"Username\": \"{username}\", \"Password\": \"{password}\" }}";
            System.IO.File.WriteAllText("./DataAccess/configSQL.json", jsonConfig);
            MessageBox.Show("Configuración guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonProbarConexion_Click(object sender, EventArgs e)
        {
            if (db.ProbarConexion())
            {
                MessageBox.Show("Conexión exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRespaldar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Backup Files (*.bak)|*.bak";
                sfd.Title = "Seleccione ubicación para guardar el respaldo";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string resultado = db.HacerBackup(sfd.FileName);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormBaseDeDatos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string datos = db.ObtenerDatos();
            // Dividir el connString en partes
            var parts = datos.Split(';');

            // Asignar los valores a los textbox
            foreach (var part in parts)
            {
                if (part.StartsWith("Server="))
                {
                    textBoxServidor.Text = part.Substring("Server=".Length);
                }
                else if (part.StartsWith("Database="))
                {
                    textBoxNombreDB.Text = part.Substring("Database=".Length);
                }
                else if (part.StartsWith("User Id="))
                {
                    textBoxUsuario.Text = part.Substring("User Id=".Length);
                }
                else if (part.StartsWith("Password="))
                {
                    textBoxContraseña.Text = part.Substring("Password=".Length);
                }
            }
        }
    }
}
