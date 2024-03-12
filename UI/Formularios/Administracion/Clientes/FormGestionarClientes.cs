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
using UI.Formularios.Pedidos;

namespace UI.Formularios.Administracion.Clientes
{
    public partial class FormGestionarClientes : Form
    {
        CN_Clientes clientes;
        public FormGestionarClientes()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Cliente"].Value);
                // Cerrar el formulario GestionarClientes con resultado OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente primero.");
            }
        }

        public int ObtenerIDClienteSeleccionado()
        {
            // Obtener el ID_Cliente seleccionado del DataGridView
            int idClienteSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Cliente"].Value);

            return idClienteSeleccionado;
        }

        private void FormGestionarClientes_Load(object sender, EventArgs e)
        {
            clientes = CN_Clientes.ObtenerInstancia();
            try
            {
                dataGridView1.DataSource = clientes.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
