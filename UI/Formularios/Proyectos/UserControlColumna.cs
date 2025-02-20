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
            flowLayoutPanelDeTarjetas.AllowDrop = true;
            flowLayoutPanelDeTarjetas.DragEnter += flowLayoutPanelDeTarjetas_DragEnter;
            flowLayoutPanelDeTarjetas.DragDrop += flowLayoutPanelDeTarjetas_DragDrop;
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
            using (FormDetalleTarjeta formulario = FormDetalleTarjeta.ObtenerInstancia(ObjetoColumna))
            {
                formulario.ShowDialog();
            }
            AgregarTarjetaClicked?.Invoke(this, EventArgs.Empty);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CN_Columnas.ObtenerInstancia().BajaColumna(columnaDB.ID_Columna);
            FlowLayoutPanel parent = this.Parent as FlowLayoutPanel;

            if (parent != null)
            {
                // Remover este UserControl del FlowLayoutPanel
                parent.Controls.Remove(this);

                // Liberar recursos si es necesario
                this.Dispose();
            }
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void textBoxTituloColumna_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxTituloColumna.Text))
            {
                columnaEditada = columnaDB;
                columnaEditada.Nombre = textBoxTituloColumna.Text.Trim();
                CN_Columnas.ObtenerInstancia().ModificarColumna(columnaEditada);
            }
            else
            {
                MessageBox.Show("Las columnas deben tener un titulo");
                textBoxTituloColumna.Focus();
            }
        }

        private void flowLayoutPanelDeTarjetas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(UserControlTarjeta)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void flowLayoutPanelDeTarjetas_DragDrop(object sender, DragEventArgs e)
        {
            UserControlTarjeta tarjetaMovida = (UserControlTarjeta)e.Data.GetData(typeof(UserControlTarjeta));

            if (tarjetaMovida.ObjetoTarjeta.ID_Columna != this.columnaDB.ID_Columna)
            {
                // La tarjeta se movió a otra columna
                int idColumnaOrigen = tarjetaMovida.ObjetoTarjeta.ID_Columna;
                tarjetaMovida.ObjetoTarjeta.ID_Columna = this.columnaDB.ID_Columna;
                if (flowLayoutPanelDeTarjetas.Controls.OfType<UserControlTarjeta>().Count() == 0)
                {
                    tarjetaMovida.ObjetoTarjeta.Posicion = 1;
                } else
                {
                    int maxPosicion = flowLayoutPanelDeTarjetas.Controls.OfType<UserControlTarjeta>().Max(uc => uc.ObjetoTarjeta.Posicion);
                    tarjetaMovida.ObjetoTarjeta.Posicion = maxPosicion + 1;
                }
                CN_Tarjetas.ObtenerInstancia().ModificarTarjeta(tarjetaMovida.ObjetoTarjeta);
                cargarTarjetas();
                
                // Buscar y refrescar la columna de origen
                foreach (UserControlColumna controlColumna in this.Parent.Controls.OfType<UserControlColumna>())
                {
                    if (controlColumna.ObjetoColumna.ID_Columna == idColumnaOrigen)
                    {
                        controlColumna.cargarTarjetas(); // 🔹 Actualizar la columna original
                        break; // No es necesario seguir buscando
                    }
                }
            }
            else
            {
                // Obtener la nueva posición dentro de la columna actual
                Point puntoSoltado = flowLayoutPanelDeTarjetas.PointToClient(new Point(e.X, e.Y));
                int nuevaPosicion = ObtenerPosicionEnFlowLayout(puntoSoltado);
                if (nuevaPosicion >= 0)
                {
                    MoverTarjetaPorArrastre(tarjetaMovida, nuevaPosicion);
                }   
            }
        }



        private int ObtenerPosicionEnFlowLayout(Point punto)
        {
            for (int i = 0; i < flowLayoutPanelDeTarjetas.Controls.Count; i++)
            {
                Control control = flowLayoutPanelDeTarjetas.Controls[i];

                if (control.Bounds.Contains(punto))
                {
                    return i;
                }
            }
            return -1; // Si no se encuentra la posición
        }

        private void MoverTarjetaPorArrastre(UserControlTarjeta tarjetaMovida, int nuevaPosicion)
        {
            List<Tarjeta> tarjetasDeColumna = CN_Tarjetas.ObtenerInstancia()
                                                          .ObtenerTodasLasTarjetasDeLaColumna(columnaDB.ID_Columna)
                                                          .OrderBy(t => t.Posicion)
                                                          .ToList();

            // Buscar la tarjeta en la lista
            int posicionActual = tarjetasDeColumna.FindIndex(t => t.ID_Tarjeta == tarjetaMovida.ObjetoTarjeta.ID_Tarjeta);

            // Validar si la tarjeta está en la lista
            if (posicionActual == -1)
            {
                // Esto indica que la tarjeta no estaba en la columna actual (se está moviendo desde otra columna)
                tarjetaMovida.ObjetoTarjeta.ID_Columna = columnaDB.ID_Columna;
                tarjetaMovida.ObjetoTarjeta.Posicion = nuevaPosicion + 1;

                CN_Tarjetas.ObtenerInstancia().ModificarTarjeta(tarjetaMovida.ObjetoTarjeta);
                cargarTarjetas();
                return;
            }

            // Validar si la posición es válida antes de acceder a la lista
            if (posicionActual != nuevaPosicion && nuevaPosicion >= 0 && nuevaPosicion < tarjetasDeColumna.Count)
            {
                Tarjeta tarjetaDB = tarjetasDeColumna[posicionActual];
                tarjetasDeColumna.RemoveAt(posicionActual);
                tarjetasDeColumna.Insert(nuevaPosicion, tarjetaDB);

                // Reasignar posiciones en la base de datos
                for (int i = 0; i < tarjetasDeColumna.Count; i++)
                {
                    tarjetasDeColumna[i].Posicion = i + 1; // Ajustar a base 1
                    CN_Tarjetas.ObtenerInstancia().ModificarTarjeta(tarjetasDeColumna[i]);
                }

                // Recargar UI
                cargarTarjetas();
            }
        }
    }
}
