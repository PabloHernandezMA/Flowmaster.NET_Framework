using Dominio.Aplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Proyectos
{
    public partial class FormDetalleTarjeta : Form
    {
        private int idTarjeta;
        private static FormDetalleTarjeta instancia;
        private Tarjeta estaTarjeta;
        private FormDetalleTarjeta()
        {
            InitializeComponent();
            idTarjeta = 0;
        }
        private FormDetalleTarjeta(Tarjeta tarjeta)
        {
            InitializeComponent();
            estaTarjeta = tarjeta;
            idTarjeta = estaTarjeta.ID_Tarjeta;
            cargarDatos();
        }
        public static FormDetalleTarjeta ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormDetalleTarjeta();
            }
            return instancia;
        }
        public static FormDetalleTarjeta ObtenerInstancia(Tarjeta tarjeta)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormDetalleTarjeta(tarjeta);
            }
            return instancia;
        }
        private void cargarDatos()
        {
            CN_Columnas columnas = CN_Columnas.ObtenerInstancia();
            List<Columna> columnasDelProyecto = columnas.ObtenerTodasLasColumnasDelProyectoPorTarjeta(estaTarjeta.ID_Tarjeta);
            comboBoxColumna.DataSource = columnasDelProyecto;
            comboBoxColumna.DisplayMember = "Nombre";
            comboBoxColumna.ValueMember = "ID_Columna";
            textBoxTitulo.Text = estaTarjeta.Nombre;
            textBoxDescTarjeta.Text = estaTarjeta.Descripcion;
            comboBoxColumna.SelectedValue = estaTarjeta.ID_Columna;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos())
            {
                MessageBox.Show("Verifique los campos del formulario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tarjeta tarjeta = new Tarjeta
            {
                ID_Tarjeta = idTarjeta,
                Nombre = textBoxTitulo.Text.Trim(),
                Descripcion = textBoxDescTarjeta.Text.Trim(),
                ID_Columna = (int)comboBoxColumna.SelectedValue
            };

            int filasAfectadas = tarjeta.ID_Tarjeta == 0
                ? CN_Tarjetas.ObtenerInstancia().AltaTarjeta(tarjeta)
                : CN_Tarjetas.ObtenerInstancia().ModificarTarjeta(tarjeta);

            MessageBox.Show(filasAfectadas > 0
                ? "Tarjeta guardada correctamente."
                : "No se pudo completar la operación.");
        }
        private bool VerificarCampos()
        {
            errorProvider1.Clear();
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
            {
                errorProvider1.SetError(textBoxTitulo, "El nombre no puede estar vacío");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDescTarjeta.Text))
            {
                errorProvider1.SetError(textBoxDescTarjeta, "La descripcion no puede estar vacía");
                esValido = false;
            }
            return esValido;
        }
    }
}
