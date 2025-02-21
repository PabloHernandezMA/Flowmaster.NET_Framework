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
using UI.Formularios.Administracion.Empleados;

namespace UI.Formularios.Proyectos
{
    public partial class FormDetalleTarjeta : Form
    {
        public Tarjeta ObjetoTarjeta { get; set; }
        private int idTarjeta;
        private static FormDetalleTarjeta instancia;
        private Tarjeta estaTarjeta;
        private List<Empleado_Tarjeta> listaIntegrantes;
        private FormDetalleTarjeta()
        {
            InitializeComponent();
            idTarjeta = 0;
        }
        private FormDetalleTarjeta(Tarjeta tarjeta)
        {
            InitializeComponent();
            estaTarjeta = tarjeta;
            ObjetoTarjeta = tarjeta;
            idTarjeta = estaTarjeta.ID_Tarjeta;
            cargarDatos();
        }
        private FormDetalleTarjeta(Columna columna)
        {
            InitializeComponent();
            idTarjeta = 0;
            List<Columna> columnas = CN_Columnas.ObtenerInstancia().ObtenerTodasLasColumnasDelProyecto(columna.ID_Proyecto);
            comboBoxColumna.DataSource = columnas;
            comboBoxColumna.DisplayMember = "Nombre";
            comboBoxColumna.ValueMember = "ID_Columna";
            comboBoxColumna.SelectedItem = columnas.FirstOrDefault(c => c.ID_Columna == columna.ID_Columna);
        }
        public static FormDetalleTarjeta ObtenerInstancia(Columna columna)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormDetalleTarjeta(columna);
            }
            return instancia;
        }
        public static FormDetalleTarjeta ObtenerInstancia(Tarjeta tarjeta)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormDetalleTarjeta(tarjeta);
            }
            return instancia;
        }
        private void cargarDatos()
        {
            CN_Columnas columnas = CN_Columnas.ObtenerInstancia();
            List<Columna> columnasDelProyecto = columnas.ObtenerTodasLasColumnasDelProyectoPorTarjeta(estaTarjeta.ID_Tarjeta);
            comboBoxColumna.DataSource = columnasDelProyecto;
            comboBoxColumna.DisplayMember = "Nombre";
            comboBoxColumna.ValueMember = "ID_Columna";
            comboBoxColumna.SelectedItem = columnasDelProyecto.FirstOrDefault(c => c.ID_Columna == estaTarjeta.ID_Columna);
            textBoxTitulo.Text = estaTarjeta.Nombre;
            textBoxDescTarjeta.Text = estaTarjeta.Descripcion;
            comboBoxColumna.SelectedValue = estaTarjeta.ID_Columna;
            cargarTareas();
            if (idTarjeta!=0) { CargarEmpleados(CN_Tarjetas.ObtenerInstancia().ObtenerTodosLosEmpleadosDeLaTarjeta(idTarjeta)); }
        }
        // Agregar como campo de la clase
        //private Dictionary<string, TareaTarjeta> tareasDict = new Dictionary<string, TareaTarjeta>();

        private void cargarTareas()
        {
            List<TareaTarjeta> tareas = CN_Tarjetas.ObtenerInstancia().ObtenerTodasLasTareasDeLaTarjeta(ObjetoTarjeta.ID_Tarjeta);

            if (tareas != null && tareas.Count > 0)
            {
                flowLayoutPanelTareas.Controls.Clear();

                foreach (var tarea in tareas)
                {
                    UserControlCheck control = new UserControlCheck(tarea);
                    control.CheckBoxChanged += Tarea_CheckBoxChanged;
                    flowLayoutPanelTareas.Controls.Add(control);
                }
            }

            // Actualizar el progreso inicial después de cargar las tareas
            ActualizarProgreso();
        }
        private void Tarea_CheckBoxChanged(object sender, EventArgs e)
        {
            ActualizarProgreso();
        }
        private void ActualizarProgreso()
        {
            // Obtener el total de tareas en el FlowLayoutPanel
            int totalTareas = flowLayoutPanelTareas.Controls.Count;
            int tareasCompletadas = 0;

            // Recorrer los controles de tipo UserControlCheck
            foreach (Control control in flowLayoutPanelTareas.Controls)
            {
                if (control is UserControlCheck userControl)
                {
                    // Verificar si la tarea está completada
                    if (userControl.ObjetoTareaTarjeta != null && userControl.ObjetoTareaTarjeta.Completada)
                    {
                        tareasCompletadas++;
                    }
                }
            }

            // Actualizar el texto de labelProgresoTareas
            labelProgresoTareas.Text = $"Progreso: {tareasCompletadas}/{totalTareas}";

            // Calcular el porcentaje de progreso (evitar división por cero)
            int porcentajeProgreso = (totalTareas > 0) ? (tareasCompletadas * 100) / totalTareas : 0;

            // Actualizar el valor de progressBarTareas
            progressBarTareas.Value = porcentajeProgreso;
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

            Tarjeta tarjeta = new Tarjeta
            {
                ID_Tarjeta = idTarjeta,
                Nombre = textBoxTitulo.Text.Trim(),
                Descripcion = textBoxDescTarjeta.Text.Trim(),
                Visible = true,
                ID_Columna = (int)comboBoxColumna.SelectedValue
            };
            int filasAfectadas;
            if (tarjeta.ID_Tarjeta == 0)
            {
                // Alta de nuevo proyecto
                filasAfectadas = CN_Tarjetas.ObtenerInstancia().AltaTarjeta(tarjeta);
                List<Tarjeta> listaTarjetas = CN_Tarjetas.ObtenerInstancia().ObtenerTodasLasTarjetasDeLaColumna((int)comboBoxColumna.SelectedValue);
                Tarjeta ultimaTarjeta = listaTarjetas.OrderByDescending(p => p.ID_Tarjeta).FirstOrDefault();
                idTarjeta = ultimaTarjeta.ID_Tarjeta;
                foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
                {
                    if (row.DataBoundItem is Empleado_Tarjeta empleado)
                    {
                        empleado.ID_Tarjeta = ultimaTarjeta.ID_Tarjeta;
                    }
                }
                foreach (UserControlCheck control in flowLayoutPanelTareas.Controls)
                {
                    control.ObjetoTareaTarjeta.ID_Tarjeta = idTarjeta;
                }
                GuardarEmpleados();
                GuardarTareas();
                GestorTareas.ObtenerInstancia().NotificarObservadores();
            }
            else
            {
                // Modificación de proyecto existente
                filasAfectadas = CN_Tarjetas.ObtenerInstancia().ModificarTarjeta(tarjeta);
                GuardarEmpleados();
                GuardarTareas();
                GestorTareas.ObtenerInstancia().NotificarObservadores();
            }
            MessageBox.Show(filasAfectadas > 0
                ? "Tarjeta guardada correctamente."
                : "No se pudo completar la operación.");
        }
        private void GuardarTareas()
        {
            List<TareaTarjeta> listaTareas = new List<TareaTarjeta>();
            foreach (UserControlCheck control in flowLayoutPanelTareas.Controls)
            {
                TareaTarjeta tarea = control.ObjetoTareaTarjeta;
                listaTareas.Add(tarea);
            }
            int resultado = CN_Tarjetas.ObtenerInstancia().ModificarTareaTarjetas(listaTareas, idTarjeta);
        }
        private void GuardarEmpleados()
        {
            List<Empleado_Tarjeta> listaIntegrantes = new List<Empleado_Tarjeta>();
            foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
            {
                if (!row.IsNewRow)
                {
                    Empleado_Tarjeta integrante = (Empleado_Tarjeta)row.DataBoundItem;
                    listaIntegrantes.Add(integrante);
                }
            }
            int resultado = CN_Tarjetas.ObtenerInstancia().ModificarEmpleadoTarjetas(listaIntegrantes, idTarjeta);
        }

        private bool VerificarCampos()
        {
            errorProvider1.Clear();
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
            {
                errorProvider1.SetError(textBoxTitulo, "El nombre no puede estar vacío");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDescTarjeta.Text))
            {
                errorProvider1.SetError(textBoxDescTarjeta, "La descripcion no puede estar vacía");
                esValido = false;
            }
            foreach (UserControlCheck control in flowLayoutPanelTareas.Controls)
            {
                if (string.IsNullOrWhiteSpace(control.Descripcion.Text))
                {
                    errorProvider1.SetError(control.Descripcion, "La descripcion no puede estar vacía");
                    esValido = false;
                }
            }
            return esValido;
        }

        private void buttonAddEdit_Click(object sender, EventArgs e)
        {
            UserControlCheck control = new UserControlCheck();
            control.CheckBoxChanged += Tarea_CheckBoxChanged;
            flowLayoutPanelTareas.Controls.Add(control);
            ActualizarProgreso();
        }

        private void flowLayoutPanelTareas_ControlRemoved(object sender, ControlEventArgs e)
        {
            ActualizarProgreso();
        }

        private void buttonAgregarEmpleado_Click(object sender, EventArgs e)
        {
            FormGestionarEmpleados form = FormGestionarEmpleados.ObtenerInstancia(1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Empleado empleadoSeleccionado = form.EmpleadoSeleccionado;
                if (listaIntegrantes == null)
                {
                    listaIntegrantes = new List<Empleado_Tarjeta>();
                }
                if (empleadoSeleccionado != null && !listaIntegrantes.Any(i => i.ID_Empleado == empleadoSeleccionado.ID_Empleado))
                {
                    Empleado_Tarjeta nuevoIntegrante = new Empleado_Tarjeta
                    {
                        Nombre = empleadoSeleccionado.Nombre,
                        ID_Empleado = empleadoSeleccionado.ID_Empleado,
                        ID_Tarjeta = idTarjeta == 0 ? 0 : idTarjeta
                    };
                    // List<Integrante> listaIntegrantes = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(esteProyecto.ID_Proyecto);
                    listaIntegrantes.Add(nuevoIntegrante);
                    CargarEmpleados(listaIntegrantes);
                }
            }
        }
        private void CargarEmpleados(List<Empleado_Tarjeta> listaDeIntegrantes)
        {
            // Configurar DataGridView
            dataGridViewEmpleados.AutoGenerateColumns = false;
            dataGridViewEmpleados.Columns.Clear();

            // Crear columnas manualmente
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            colNombre.ReadOnly = true; // Solo lectura
            dataGridViewEmpleados.Columns.Add(colNombre);

            // Asignar la lista de integrantes al DataGridView
            dataGridViewEmpleados.DataSource = listaDeIntegrantes;
        }

        private void buttonEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Crear una lista para almacenar los integrantes
                listaIntegrantes = new List<Empleado_Tarjeta>();
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewEmpleados.SelectedRows[0];

                // Obtener el objeto Integrante correspondiente a la fila seleccionada
                Empleado_Tarjeta integranteSeleccionado = (Empleado_Tarjeta)filaSeleccionada.DataBoundItem;

                // Obtener la lista de Integrantes del DataSource del DataGridView
                listaIntegrantes = (List<Empleado_Tarjeta>)dataGridViewEmpleados.DataSource;

                // Eliminar el objeto Integrante de la lista
                listaIntegrantes.Remove(integranteSeleccionado);
                dataGridViewEmpleados.DataSource = null;
                CargarEmpleados(listaIntegrantes);
            }
        }
    }
}
