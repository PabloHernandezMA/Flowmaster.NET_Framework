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
    public partial class UserControlCheck : UserControl
    {
        public TareaTarjeta ObjetoTareaTarjeta { get; set; }
        public TextBox Descripcion { get {return textBoxDescripcion; } }
        public UserControlCheck()
        {
            InitializeComponent();
            ObjetoTareaTarjeta = new TareaTarjeta();
            ObjetoTareaTarjeta.Completada = false;
            ObjetoTareaTarjeta.Descripcion = "";
            CargarDatos();
        }
        public UserControlCheck(TareaTarjeta tarea)
        {
            InitializeComponent();
            ObjetoTareaTarjeta = tarea;
            CargarDatos();
        }
        private void CargarDatos()
        {
            checkBoxCompletada.Checked = ObjetoTareaTarjeta.Completada;
            textBoxDescripcion.Text = ObjetoTareaTarjeta.Descripcion;
        }

        private void buttonEliminarTarea_Click(object sender, EventArgs e)
        {
            // Obtener el control padre del UserControlCheck (que será FlowLayoutPanel)
            FlowLayoutPanel parent = this.Parent as FlowLayoutPanel;

            if (parent != null)
            {
                // Remover este UserControl del FlowLayoutPanel
                parent.Controls.Remove(this);

                // Liberar recursos si es necesario
                this.Dispose();
            }
        }

        public event EventHandler CheckBoxChanged;
        private void checkBoxCompletada_CheckedChanged(object sender, EventArgs e)
        {
            this.ObjetoTareaTarjeta.Completada = checkBoxCompletada.Checked;
            CheckBoxChanged?.Invoke(this, EventArgs.Empty);
        }

        private void textBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
            ObjetoTareaTarjeta.Descripcion = textBoxDescripcion.Text;
        }
    }
}
