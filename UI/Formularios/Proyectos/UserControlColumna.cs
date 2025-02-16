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
    public partial class UserControlColumna : UserControl
    {
        CN_Tarjetas tarjetas;
        public event EventHandler AgregarTarjetaClicked;
        public event EventHandler EliminarColumnaClicked;
        
        public UserControlColumna()
        {
            InitializeComponent();
            panelTop.MouseDown += panelTop_MouseDown;
        }

        private Columna columnaDB;
        private Columna columnaEditada;

        public Columna ObjetoColumna { get; internal set; }

        public void ConfigurarColumna(Columna columnaGuardada)
        {
            columnaDB = columnaGuardada;
            ObjetoColumna = columnaGuardada;
            this.Visible = columnaDB.Visible; // Controlar la visibilidad
            textBoxTituloColumna.Text = columnaDB.Nombre;
            cargarTarjetas(); // Cargar tarjetas después de la configuración
        }
        private void cargarTarjetas()
        {
            tarjetas = CN_Tarjetas.ObtenerInstancia();
            List<Tarjeta> tarjetasDeColumna = tarjetas.ObtenerTodasLasTarjetasDeLaColumna(columnaDB.ID_Columna);
            tarjetasDeColumna = tarjetasDeColumna.OrderBy(o => o.Posicion).ToList();
            Button buttonAgregarTarjeta = this.buttonAgregarTarjeta;
            flowLayoutPanelDeTarjetas.Controls.Clear();
            
            foreach (Tarjeta tarjeta in tarjetasDeColumna)
            {
                UserControlTarjeta userControlTarjeta = new UserControlTarjeta();
                userControlTarjeta.ConfigurarTarjeta(tarjeta);
                flowLayoutPanelDeTarjetas.Controls.Add(userControlTarjeta);
            }               
            flowLayoutPanelDeTarjetas.Controls.Add(buttonAgregarTarjeta);
        }

        private void buttonAgregarTarjeta_Click(object sender, EventArgs e)
        {
            using (FormDetalleTarjeta formulario = FormDetalleTarjeta.ObtenerInstancia())
            {
                formulario.ShowDialog();
            }
            AgregarTarjetaClicked?.Invoke(this, EventArgs.Empty);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CN_Columnas.ObtenerInstancia().BajaColumna(columnaDB.ID_Columna);
            EliminarColumnaClicked?.Invoke(this, EventArgs.Empty);
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }
    }
}
