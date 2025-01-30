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
        public UserControlColumna()
        {
            InitializeComponent();
        }

        public int id_Columna { get; set; }
        public string nombreColumna
        {
            get { return textBoxTituloColumna.Text; }
            set { textBoxTituloColumna.Text = value; }
        }
        public int posicion { get; set; }
        public bool visible { get; set; }
        public int id_Proyecto { get; set; }

        public void ConfigurarColumna(Columna datosColumna)
        {
            id_Columna = datosColumna.ID_Columna;
            nombreColumna = datosColumna.Nombre;
            posicion = datosColumna.Posicion;
            visible = datosColumna.Visible;
            id_Proyecto = datosColumna.ID_Proyecto;
            this.Visible = visible; // Controlar la visibilidad
            cargarTarjetas(); // Cargar tarjetas después de la configuración
        }
        private void cargarTarjetas()
        {
            tarjetas = CN_Tarjetas.ObtenerInstancia();
            List<Tarjeta> tarjetasDeColumna = tarjetas.ObtenerTodasLasTarjetasDeLaColumna(id_Columna);
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
    }
}
