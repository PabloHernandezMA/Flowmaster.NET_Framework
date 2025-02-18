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
            labelTarjeta.Text = ObjetoTarjeta.Nombre;
            labelFechaFin.Text = ObjetoTarjeta.Posicion.ToString();
        }

        private void buttonOpciones_Click(object sender, EventArgs e)
        {

        }

        private void panelRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }
    }
}
