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

namespace UI.Formularios.Pedidos
{
    public partial class FormDetalleProductoPedido : Form
    {
        private int idPedido;
        private List<Producto> listaProductos;
        // Propiedad para almacenar el objeto DetallePedido creado
        public DetallePedido DetallePedidoCreado { get; private set; }
        public FormDetalleProductoPedido(int idPedido)
        {
            InitializeComponent();
            this.idPedido = idPedido;
        }

        private void FormDetalleProductoPedido_Load(object sender, EventArgs e)
        {
            listaProductos = CN_Productos.ObtenerInstancia().ObtenerTodosLosProductos();
            comboBoxProducto.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
            comboBoxProducto.ValueMember = "ID_Producto"; // Indica la propiedad que se utilizará como valor seleccionado
            comboBoxProducto.DataSource = listaProductos;
            // Habilitamos el autocompletado
            comboBoxProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Convertir los valores a los tipos de datos adecuados
            int idProducto = (int)comboBoxProducto.SelectedValue; // Suponiendo que el valor seleccionado es un entero
            float cantidad = float.Parse(textBoxCantidad.Text); // Convertir el texto a float para la cantidad
            decimal totalDetalle = decimal.Parse(labelTotal.Text); // Convertir el texto a decimal para el total
            decimal precioUnitario = decimal.Parse(textBoxPrecioU.Text); // Convertir el texto a decimal para el precio unitario

            // Crear el objeto DetallePedido con los datos del formulario
            DetallePedidoCreado = new DetallePedido
            {
                ID_Pedido = idPedido,
                ID_Producto = idProducto,
                Cantidad = cantidad,
                TotalDetalle = totalDetalle,
                PrecioUnitario = precioUnitario
            };

            // Cerrar el formulario
            this.Close();
        }

        private Producto BuscarProductoPorID(int idProducto)
        {
            // Buscar el producto por ID_Producto en la lista
            Producto productoEncontrado = listaProductos.Find(producto => producto.ID_Producto == idProducto);

            return productoEncontrado;
        }


        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID_Producto seleccionado del comboBoxProducto
            int idSeleccionado = Convert.ToInt32(comboBoxProducto.SelectedValue);

            // Buscar el producto en la lista utilizando el ID_Producto seleccionado
            Producto productoSeleccionado = BuscarProductoPorID(idSeleccionado);

            // Hacer lo que necesites con el producto encontrado, por ejemplo, mostrar sus propiedades
            if (productoSeleccionado != null)
            {
                textBoxCantidad.Text = "1";
                textBoxPrecioU.Text = productoSeleccionado.PrecioVenta.ToString();
                labelExistencias.Text = productoSeleccionado.Existencias.ToString();
                ActualizarTotal();
            }
            else
            {
                Console.WriteLine("Producto no encontrado en la lista.");
            }
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void textBoxPrecioU_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }
        private void ActualizarTotal()
        {
            // Verificar si los valores son numéricos
            if (double.TryParse(textBoxCantidad.Text, out double cantidad) && double.TryParse(textBoxPrecioU.Text, out double precioUnitario))
            {
                // Calcular el total
                double total = cantidad * precioUnitario;

                // Actualizar el valor de labelTotal.Text con el total calculado
                labelTotal.Text = total.ToString();
            }
            else
            {
                // Manejar el caso en que los valores ingresados no sean numéricos
                labelTotal.Text = "Error";
            }
        }
    }
}
