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
            if (this.Modal)
            {
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
            } else
            {
                buttonSeleccionar.Visible = false;
            }
            // Inicializar variables
            pageIndex = 0;

            // Configurar el DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        // Variables de clase
        private List<Pedido> pedidosDB;
        private List<Cliente> clientesDB;
        private List<Sucursal> sucursalesDB;
        private int pageIndex = 0;
        private int pageSize = 25; // Filas por página
        private int totalPages = 0;

        // Método para cargar y paginar los datos
        private void LoadData()
        {
            try
            {
                // Cargar datos solo si no están cargados
                if (pedidosDB == null)
                    pedidosDB = CN_Pedidos.ObtenerInstancia().ObtenerTodosLosPedidos();

                if (clientesDB == null)
                    clientesDB = CN_Clientes.ObtenerInstancia().ObtenerTodosLosClientes();

                if (sucursalesDB == null)
                    sucursalesDB = CN_Sucursales.ObtenerInstancia().ObtenerTodasLasSucursales();

                // Calcular la cantidad total de páginas
                totalPages = (int)Math.Ceiling((double)pedidosDB.Count() / pageSize);

                // Obtener los datos para la página actual
                var datos = pedidosDB.Skip(pageIndex * pageSize).Take(pageSize).ToList();

                // Limpiar los controladores de eventos para evitar duplicados
                dataGridView1.CellFormatting -= DataGridView1_CellFormatting;

                // Asignar los datos al DataGridView
                dataGridView1.DataSource = datos;

                // Configurar las columnas
                dataGridView1.Columns["ID_Pedido"].HeaderText = "Número de Pedido";
                dataGridView1.Columns["ID_Cliente"].HeaderText = "Cliente";
                dataGridView1.Columns["ID_Sucursal"].HeaderText = "Sucursal";
                dataGridView1.Columns["FechaInicio"].HeaderText = "Fecha de Ingreso";
                dataGridView1.Columns["DescripcionSolicitud"].HeaderText = "Descripción";

                // Configurar formato de fecha si es necesario
                dataGridView1.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Ocultar las columnas que no quieres mostrar
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Name != "ID_Pedido" &&
                        col.Name != "ID_Cliente" &&
                        col.Name != "ID_Sucursal" &&
                        col.Name != "FechaInicio" &&
                        col.Name != "DescripcionSolicitud")
                    {
                        col.Visible = false;
                    }
                }

                // Añadir el controlador de eventos para formatear las celdas
                dataGridView1.CellFormatting += DataGridView1_CellFormatting;

                // Actualizar la etiqueta de paginación
                labelNumeroDePagina.Text = $"{pageIndex + 1} / {totalPages}";

                // Habilitar/deshabilitar botones de navegación según corresponda
                linkLabelPaginaPrevia.Enabled = (pageIndex > 0);
                linkLabelPaginaSiguiente.Enabled = (pageIndex < totalPages - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejador de eventos para formatear celdas
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Value != null)
            {
                try
                {
                    // Formatear columna de cliente
                    if (e.ColumnIndex == dataGridView1.Columns["ID_Cliente"].Index)
                    {
                        int clienteId = Convert.ToInt32(e.Value);
                        Cliente cliente = clientesDB.FirstOrDefault(c => c.ID_Cliente == clienteId);
                        if (cliente != null)
                        {
                            e.Value = cliente.Nombre;
                            e.FormattingApplied = true;
                        }
                    }
                    // Formatear columna de sucursal
                    else if (e.ColumnIndex == dataGridView1.Columns["ID_Sucursal"].Index)
                    {
                        int sucursalId = Convert.ToInt32(e.Value);
                        Sucursal sucursal = sucursalesDB.FirstOrDefault(s => s.ID_Sucursal == sucursalId);
                        if (sucursal != null)
                        {
                            e.Value = sucursal.Nombre;
                            e.FormattingApplied = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Solo registramos el error, no mostramos mensaje para no interrumpir la experiencia
                    Console.WriteLine("Error en formateo de celda: " + ex.Message);
                }
            }
        }

        // Método para navegar a la página anterior
        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            if (pageIndex > 0)
            {
                pageIndex--;
                LoadData();
            }
        }

        // Método para navegar a la página siguiente
        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            if (pageIndex < totalPages - 1)
            {
                pageIndex++;
                LoadData();
            }
        }

        // Método para refrescar los datos
        public void RefreshData()
        {
            // Limpiar las listas para que se vuelvan a cargar
            pedidosDB = null;
            clientesDB = null;
            sucursalesDB = null;

            // Reiniciar a la primera página
            pageIndex = 0;

            // Volver a cargar los datos
            LoadData();
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

        public Pedido pedidoSeleccionado { get; private set; }
        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            pedidoSeleccionado = ObtenerPedidoSeleccionado();
            if (pedidoSeleccionado != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido.");
            }
        }
        // Eliminar la definición duplicada del método ObtenerPedidoSeleccionado
        internal Pedido ObtenerPedidoSeleccionado()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                return (Pedido)dataGridView1.SelectedRows[0].DataBoundItem;
            }
            else
            {
                return null;
            }
        }
    }
}
