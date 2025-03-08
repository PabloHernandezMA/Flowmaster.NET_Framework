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
    public partial class UserControlTarjeta : UserControl
    {
        public Tarjeta ObjetoTarjeta { get; set; }

        public UserControlTarjeta()
        {
            InitializeComponent();
            panelRight.MouseDown += panelRight_MouseDown;
        }
        public void ConfigurarTarjeta(Tarjeta datosTarjeta)
        {
            ObjetoTarjeta = datosTarjeta;
            this.Visible = ObjetoTarjeta.Visible; // Controlar la visibilidad
            ActualizarFormulario();
        }
        public void ActualizarFormulario()
        {
            // Obtener todas las tareas de la tarjeta
            var tareas = CN_Tarjetas.ObtenerInstancia().ObtenerTodasLasTareasDeLaTarjeta(ObjetoTarjeta.ID_Tarjeta);
            // Contar el número total de tareas
            int totalTareas = tareas.Count();
            // Contar el número de tareas completadas
            int tareasCompletadas = tareas.Count(t => t.Completada);

            labelTarjeta.Text = ObjetoTarjeta.Nombre;
            labelFechaFin.Text = $"Tareas: {tareasCompletadas}/{totalTareas}";
        }

        private void panelRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void abrirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (FormDetalleTarjeta formulario = FormDetalleTarjeta.ObtenerInstancia(ObjetoTarjeta))
            {
                formulario.ShowDialog();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de querer eliminar la tarjeta?",
                                                      "Confirmar Eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                CN_Tarjetas.ObtenerInstancia().BajaTarjeta(ObjetoTarjeta.ID_Tarjeta);
                // Obtener el control padre del UserControlCheck (que será FlowLayoutPanel)
                FlowLayoutPanel parent = this.Parent as FlowLayoutPanel;

                if (parent != null)
                {
                    // Remover este UserControl del FlowLayoutPanel
                    parent.Controls.Remove(this);

                    // Liberar recursos si es necesario
                    this.Dispose();
                }
                MessageBox.Show("La tarjeta ha sido eliminada.");
                GestorTareas.ObtenerInstancia().NotificarObservadores();
            }
            else
            {
                MessageBox.Show("La eliminación ha sido cancelada.");
            }
        }
    }
}
