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

        private Columna columnaDB;
        private Columna columnaEditada;

        public void ConfigurarColumna(Columna columnaGuardada)
        {
            columnaDB = columnaGuardada;
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
    }
}
