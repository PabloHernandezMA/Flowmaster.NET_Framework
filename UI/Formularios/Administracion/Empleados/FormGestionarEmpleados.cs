using Dominio.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Administracion.Empleados
{
    public partial class FormGestionarEmpleados : Form
    {
        public FormGestionarEmpleados()
        {
            InitializeComponent();
        }

        internal int ObtenerIDEmpleadoSeleccionado()
        {
            // Obtener el ID_Cliente seleccionado del DataGridView
            int idEmpleadoSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Empleado"].Value);

            return idEmpleadoSeleccionado;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormGestionarEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
