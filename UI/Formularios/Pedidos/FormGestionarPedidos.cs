using Dominio.Aplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Formularios.Productos;

namespace UI.Formularios.Pedidos
{
    public partial class FormGestionarPedidos : Form
    {
        private static FormGestionarPedidos instance;
        private CN_Pedidos pedidos;
        private int modoFormDetalles;
        private FormGestionarPedidos()
        {
            InitializeComponent();
        }

        public static FormGestionarPedidos GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarPedidos();
            }
            return instance;
        }
        private void FormGestionarPedidos_Load(object sender, EventArgs e)
        {
            pedidos = CN_Pedidos.ObtenerInstancia();
        }

        private int pageIndex = 0;
        private int pageSize = 30;
        private int totalPages = 0;
        private List<Pedido> pedidosDB;
        private void LoadData()
        {
            try
            {
                pedidosDB = pedidos.ObtenerTodosLosPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // Calcula la cantidad total de páginas
            totalPages = (int)Math.Ceiling((double)pedidosDB.Count() / pageSize);

            // Carga los datos para la página actual
            var datos = pedidosDB.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            // Asigna los datos al DataGridView
            dataGridView1.DataSource = datos;

            // Actualiza la etiqueta de paginación
            labelNumeroDePagina.Text = $"{pageIndex + 1} / {totalPages}";
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            // Avanza a la página siguiente
            if (pageIndex < totalPages - 1)
            {
                pageIndex++;
                LoadData();
            }
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            // Retrocede a la página anterior
            if (pageIndex > 0)
            {
                pageIndex--;
                LoadData();
            }
        }



        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                modoFormDetalles = 0;
                int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Pedido"].Value);

                // Usando el bloque using, se asegura de que la instancia del formulario se libere correctamente
                using (FormDetallesPedido formulario = FormDetallesPedido.ObtenerInstancia(idSeleccion, modoFormDetalles))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido primero.");
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            modoFormDetalles = 1;
            using (FormDetallesPedido formulario = FormDetallesPedido.ObtenerInstancia(modoFormDetalles))
            {
                formulario.ShowDialog();
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                modoFormDetalles = 2;
                int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Pedido"].Value);
                using (FormDetallesPedido formulario = FormDetallesPedido.ObtenerInstancia(idSeleccion, modoFormDetalles))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido primero.");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idSeleccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Pedido"].Value);
                if (pedidos.BajaPedido(idSeleccion) > 0)
                {
                    MessageBox.Show("Pedido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido primero.");
            }
        }
    }
}
