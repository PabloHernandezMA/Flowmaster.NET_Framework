﻿using Dominio;
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
    public partial class FormProyecto : Form, IObserver
    {
        private CN_Proyectos proyectos;
        private Proyecto esteProyecto;
        private List<Integrante> listaIntegrantes;
        private static FormProyecto instance;
        private CN_Columnas columnas;
        private FormProyecto()
        {
            InitializeComponent();
            flowLayoutPanelTablero.AllowDrop = true;
            flowLayoutPanelTablero.DragEnter += flowLayoutPanelTablero_DragEnter;
            flowLayoutPanelTablero.DragDrop += flowLayoutPanelTablero_DragDrop;
        }
        private FormProyecto(Proyecto proyecto)
        {
            InitializeComponent();
            esteProyecto = proyecto;
            proyectos = CN_Proyectos.ObtenerInstancia();
            flowLayoutPanelTablero.AllowDrop = true;
            flowLayoutPanelTablero.DragEnter += flowLayoutPanelTablero_DragEnter;
            flowLayoutPanelTablero.DragDrop += flowLayoutPanelTablero_DragDrop;
        }

        public static FormProyecto ObtenerInstancia(Proyecto proyectoSeleccionado)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormProyecto(proyectoSeleccionado);
            }
            return instance;
        }

        private void FormProyecto_Load(object sender, EventArgs e)
        {
            cargarDatosProyecto();
            cargarColumnas(esteProyecto.ID_Proyecto);
            // Se registra como observador
            GestorTareas.ObtenerInstancia().AgregarObservador(this);
            // Carga inicial de tareas
            ActualizarProgreso();
        }
        private void cargarDatosProyecto()
        {
            this.Text = $"Proyecto: {esteProyecto.Nombre}";
            labelProyecto.Text = $"Proyecto: {esteProyecto.ID_Proyecto}";
            textBoxNombreProyecto.Text = esteProyecto.Nombre;
            dateTimePickerFechaFinProyecto.Text = esteProyecto.FechaFin.ToShortDateString();
            comboBoxEstadoProyecto.Text = esteProyecto.Estado.ToString();
            
        }
        public void Actualizar()
        {
            ActualizarProgreso();
            cargarColumnas(esteProyecto.ID_Proyecto);
        }

        private void ActualizarProgreso()
        {
            List<TareaTarjeta> tareas = CN_Tarjetas.ObtenerInstancia().ObtenerTodasLasTareasDelProyecto(esteProyecto.ID_Proyecto);

            int totalTareas = tareas.Count;
            int tareasCompletadas = tareas.Count(t => t.Completada);

            labelProgresoTareas.Text = $"Tareas: {tareasCompletadas}/{totalTareas}";

            int porcentajeProgreso = (totalTareas > 0) ? (tareasCompletadas * 100) / totalTareas : 0;
            progressBarTareas.Value = porcentajeProgreso;
        }

        private void cargarColumnas(int idProyecto)
        {
            columnas = CN_Columnas.ObtenerInstancia();
            List<Columna> columnasDelProyecto = columnas.ObtenerTodasLasColumnasDelProyecto(idProyecto).OrderBy(c => c.Posicion).ToList();
            Button buttonAgregarColumna = this.buttonAgregarColumna;
            flowLayoutPanelTablero.Controls.Clear();

            foreach (Columna columna in columnasDelProyecto)
            {
                UserControlColumna userControlColumna = new UserControlColumna();
                userControlColumna.ConfigurarColumna(columna);
                userControlColumna.AgregarTarjetaClicked += ControlColumna_AgregarTarjetaClicked;
                flowLayoutPanelTablero.Controls.Add(userControlColumna);

            }
            flowLayoutPanelTablero.Controls.Add(buttonAgregarColumna);
        }

        private void ControlColumna_AgregarTarjetaClicked(object sender, EventArgs e)
        {
            //cargarColumnas(esteProyecto.ID_Proyecto);
            //ActualizarProgreso();
        }
        private void buttonAgregarColumna_Click(object sender, EventArgs e)
        {
            if (!VerificarPermiso())
            {
                return;
            }
            int numeroDeColumnas = 0;
            numeroDeColumnas = flowLayoutPanelTablero.Controls.OfType<UserControlColumna>().Count();
            Columna objColumnaNueva = new Columna();
            objColumnaNueva.ID_Columna = 0;
            objColumnaNueva.Nombre = "Nueva*";
            objColumnaNueva.Posicion = numeroDeColumnas + 1;
            objColumnaNueva.Visible = true;
            objColumnaNueva.ID_Proyecto = esteProyecto.ID_Proyecto;
            CN_Columnas.ObtenerInstancia().AltaColumna(objColumnaNueva);
            cargarColumnas(esteProyecto.ID_Proyecto);
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            using (FormDetalleProyecto formulario = FormDetalleProyecto.ObtenerInstancia(esteProyecto))
            {
                formulario.ShowDialog();
            }
            esteProyecto = proyectos.ObtenerProyecto(esteProyecto.ID_Proyecto);
            cargarDatosProyecto();
        }

        private void flowLayoutPanelTablero_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(UserControlColumna)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void flowLayoutPanelTablero_DragDrop(object sender, DragEventArgs e)
        {
            UserControlColumna columnaMovida = (UserControlColumna)e.Data.GetData(typeof(UserControlColumna));

            // Obtener la posición donde se soltó la columna
            Point puntoSoltado = flowLayoutPanelTablero.PointToClient(new Point(e.X, e.Y));
            int nuevoIndice = ObtenerPosicionEnFlowLayout(puntoSoltado);

            if (nuevoIndice >= 0)
            {
                MoverColumnaPorArrastre(columnaMovida, nuevoIndice);
            }
        }

        private int ObtenerPosicionEnFlowLayout(Point punto)
        {
            for (int i = 0; i < flowLayoutPanelTablero.Controls.Count; i++)
            {
                Control control = flowLayoutPanelTablero.Controls[i];

                if (control.Bounds.Contains(punto))
                {
                    return i;
                }
            }
            return -1; // Si no se encuentra la posición
        }

        private void MoverColumnaPorArrastre(UserControlColumna columnaMovida, int nuevaPosicion)
        {
            if (!VerificarPermiso())
            {
                return;
            }
            List<Columna> columnasDelProyecto = columnas.ObtenerTodasLasColumnasDelProyecto(esteProyecto.ID_Proyecto)
                                                         .OrderBy(c => c.Posicion)
                                                         .ToList();

            int posicionActual = columnasDelProyecto.FindIndex(c => c.ID_Columna == columnaMovida.ObjetoColumna.ID_Columna);

            if (posicionActual != nuevaPosicion && nuevaPosicion >= 0 && nuevaPosicion < columnasDelProyecto.Count)
            {
                Columna columnaDB = columnasDelProyecto[posicionActual];
                columnasDelProyecto.RemoveAt(posicionActual);
                columnasDelProyecto.Insert(nuevaPosicion, columnaDB);

                // Reasignar posiciones en la base de datos
                for (int i = 0; i < columnasDelProyecto.Count; i++)
                {
                    columnasDelProyecto[i].Posicion = i + 1; // Ajustar a base 1
                    columnas.ActualizarColumna(columnasDelProyecto[i]);
                }

                // Recargar UI
                cargarColumnas(esteProyecto.ID_Proyecto);
            }
        }

        private void flowLayoutPanelTablero_ControlRemoved(object sender, ControlEventArgs e)
        {
            ActualizarProgreso();
        }

        private void FormProyecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Se elimina del gestor al cerrar el formulario
            GestorTareas.ObtenerInstancia().RemoverObservador(this);
        }
        private bool VerificarPermiso()
        {
            int idEmpleadoActual = CN_Empleados.ObtenerInstancia()
                .ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User)
                .ID_Empleado;
            listaIntegrantes = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(esteProyecto.ID_Proyecto);
            if (listaIntegrantes.Any(i => i.ID_Empleado == idEmpleadoActual && (i.Cargo == "Administrador" || i.Cargo == "Colaborador")))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
