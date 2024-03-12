using Dominio.Aplicacion;
using Dominio.Clases;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Administracion.Usuarios.Gestionar_Usuarios;
using UI.Formularios.Productos;

namespace UI.Productos
{
    public partial class FormGestionarProductos : Form
    {
        private CN_Productos productos;
        private int modoFormDetalles;
        private static FormGestionarProductos instance;

        private FormGestionarProductos()
        {
            InitializeComponent();
        }

        public static FormGestionarProductos GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarProductos();
            }
            return instance;
        }

        private void FormGestionarProductos_Load(object sender, EventArgs e)
        {
            productos = CN_Productos.ObtenerInstancia();
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                modoFormDetalles = 0;
                int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Producto"].Value);

                // Usando el bloque using, se asegura de que la instancia del formulario se libere correctamente
                using (FormDetallesProducto formulario = new FormDetallesProducto(idSeleccion, modoFormDetalles))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto primero.");
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            modoFormDetalles = 1;
            // Usando el bloque using, se asegura de que la instancia del formulario se libere correctamente
            using (FormDetallesProducto formulario = new FormDetallesProducto(modoFormDetalles))
            {
                formulario.ShowDialog();
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                modoFormDetalles = 2;
                int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Producto"].Value);

                // Usando el bloque using, se asegura de que la instancia del formulario se libere correctamente
                using (FormDetallesProducto formulario = new FormDetallesProducto(idSeleccion, modoFormDetalles))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto primero.");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = productos.ObtenerTodosLosProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Producto"].Value);
                if (productos.BajaProducto(idSeleccion) > 0)
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto primero.");
            }
        }
    }
}
