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
using UI.Formularios.Proyectos;

namespace UI.Formularios.Administracion.Empleados
{
    public partial class FormGestionarEmpleados : Form
    {
        private static FormGestionarEmpleados instance;
        private static int modo = 0;

        public Empleado EmpleadoSeleccionado { get; private set; }  // Propiedad para devolver el empleado seleccionado

        public FormGestionarEmpleados()
        {
            InitializeComponent();
        }

        public static FormGestionarEmpleados ObtenerInstancia()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarEmpleados();
            }
            return instance;
        }

        public static FormGestionarEmpleados ObtenerInstancia(int nuevoModo)
        {
            if (instance == null || instance.IsDisposed)
            {
                modo = nuevoModo;
                instance = new FormGestionarEmpleados();
            }
            return instance;
        }

        internal Empleado ObtenerEmpleadoSeleccionado()
        {
            // Si no hay filas seleccionadas, retorna null
            if (dataGridView1.SelectedRows.Count == 0)
                return null;

            // Obtener el objeto Empleado directamente desde el DataGridView
            return (Empleado)dataGridView1.SelectedRows[0].DataBoundItem;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            EmpleadoSeleccionado = ObtenerEmpleadoSeleccionado();
            if (EmpleadoSeleccionado != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormGestionarEmpleados_Load(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                panelABM.Visible = true;
                panelSeleccion.Visible = false;
            }

            if (modo == 1)
            {
                panelABM.Visible = false;
                panelSeleccion.Visible = true;
            }

            try
            {
                // Carga la lista de empleados desde la capa de negocio
                dataGridView1.DataSource = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
