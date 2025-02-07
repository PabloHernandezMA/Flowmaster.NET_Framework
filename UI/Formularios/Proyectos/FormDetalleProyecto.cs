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
using static UI.ValidacionesForm;

namespace UI.Formularios.Proyectos
{
    public partial class FormDetalleProyecto : Form
    {
        private static FormDetalleProyecto instance;
        private Proyecto esteProyecto;

        private FormDetalleProyecto()
        {
            InitializeComponent();
            comboBoxEstadoProyecto.SelectedIndex = 0;
        }

        private FormDetalleProyecto(Proyecto proyecto) : this()
        {
            esteProyecto = proyecto;
            RellenarCampos();
        }

        public static FormDetalleProyecto ObtenerInstancia(Proyecto proyecto = null)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = proyecto == null ? new FormDetalleProyecto() : new FormDetalleProyecto(proyecto);
            }
            return instance;
        }
        
        private void RellenarCampos()
        {
            textBoxNumero.Text = esteProyecto.ID_Proyecto.ToString();
            textBoxNombre.Text = esteProyecto.Nombre;
            comboBoxEstadoProyecto.Text = esteProyecto.Estado.ToString();
            dateTimePickerInicio.Value = esteProyecto.FechaInicio;
            dateTimePickerFin.Value = esteProyecto.FechaFin;
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

            Proyecto proyecto = new Proyecto
            {
                ID_Proyecto = string.IsNullOrWhiteSpace(textBoxNumero.Text) ? 0 : int.Parse(textBoxNumero.Text),
                Nombre = textBoxNombre.Text.Trim(),
                FechaInicio = dateTimePickerInicio.Value,
                FechaFin = dateTimePickerFin.Value,
                Estado = comboBoxEstadoProyecto.Text
            };

            int filasAfectadas = proyecto.ID_Proyecto == 0
                ? CN_Proyectos.ObtenerInstancia().AltaProyecto(proyecto)
                : CN_Proyectos.ObtenerInstancia().ModificarProyecto(proyecto);

            MessageBox.Show(filasAfectadas > 0
                ? "Proyecto guardado correctamente."
                : "No se pudo completar la operación.");
        }

        private bool VerificarCampos()
        {
            errorProvider1.Clear();
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                errorProvider1.SetError(textBoxNombre, "El nombre no puede estar vacío");
                esValido = false;
            }

            if (dateTimePickerInicio.Value >= dateTimePickerFin.Value)
            {
                errorProvider1.SetError(dateTimePickerFin, "La fecha de fin debe ser posterior a la de inicio.");
                esValido = false;
            }

            return esValido;
        }
    }
}
