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
        public int id_Tarjeta { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int posicion { get; set; }
        public bool visible { get; set; }
        public int id_Columna { get; set; }
        public UserControlTarjeta()
        {
            InitializeComponent();
        }
        public void ConfigurarTarjeta(Tarjeta datosTarjeta)
        {
            id_Tarjeta = datosTarjeta.ID_Tarjeta;
            nombre = datosTarjeta.Nombre;
            posicion = datosTarjeta.Posicion;
            descripcion = datosTarjeta.Descripcion;
            visible = datosTarjeta.Visible;
            id_Columna = datosTarjeta.ID_Columna;
            this.Visible = visible; // Controlar la visibilidad
            ActualizarFormulario();
        }
        public void ActualizarFormulario()
        {
            labelTarjeta.Text = nombre;
            labelFechaFin.Text = posicion.ToString();
        }

        private void buttonOpciones_Click(object sender, EventArgs e)
        {

        }
    }
}
