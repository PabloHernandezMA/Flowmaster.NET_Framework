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

namespace UI.Formularios.Productos
{
    public partial class FormDetallesProducto : Form
    {
        private CN_Categorias_Producto categorias;
        private CN_Tipos_Producto tipos;
        private CN_Proveedores proveedores;
        private CN_Productos productos;
        private Producto productoSeleccionado;
        private int modo; // 0 = Ver    1 = Agregar     2 = Modificar
        private int idProductoSeleccionado;

        public FormDetallesProducto(int modo)
        {
            InitializeComponent();
            this.modo = modo;
        }

        public FormDetallesProducto(int idProductoSeleccionado, int modo)
        {
            InitializeComponent();
            this.modo = modo;
            this.idProductoSeleccionado = idProductoSeleccionado;
        }

        private void FormDetallesProducto_Load(object sender, EventArgs e)
        {
            categorias = CN_Categorias_Producto.ObtenerInstancia();
            tipos = CN_Tipos_Producto.ObtenerInstancia();
            proveedores = CN_Proveedores.ObtenerInstancia();
            productos = CN_Productos.ObtenerInstancia();
            CargarCategorias();
            CargarTipo();
            CargarProveedores();
            CargarModo();
            LlenarCampos();
        }

        private void CargarModo()
        {
            if (modo == 0) //Ver
            {
                productoSeleccionado = productos.ObtenerTodosLosProductos().FirstOrDefault(p => p.ID_Producto == idProductoSeleccionado);
                buttonCancelar.Visible = false;
                buttonGuardar.Visible = false;
            }
            if (modo == 1) //Agregar
            {
                
            }
            if (modo == 2) //Modificar
            {
                productoSeleccionado = productos.ObtenerTodosLosProductos().FirstOrDefault(p => p.ID_Producto == idProductoSeleccionado);
            }
        }

        private void LlenarCampos()
        {
            // Llenar los campos del formulario con los datos del producto
            if (productoSeleccionado != null)
            {
                labelNumeroID.Text = productoSeleccionado.ID_Producto.ToString();
                textBoxNombre.Text = productoSeleccionado.Nombre;
                textBoxExistencias.Text = productoSeleccionado.Existencias.ToString();
                textBoxPrecioVenta.Text = productoSeleccionado.PrecioVenta.ToString();
                textBoxStockMinimo.Text = productoSeleccionado.StockMinimo.ToString();
                checkBoxHabilitado.Checked = productoSeleccionado.Habilitado;
                comboBoxCategoria.SelectedValue = productoSeleccionado.ID_Categoria;
                comboBoxTipo.SelectedValue = productoSeleccionado.ID_Tipo;
                comboBoxProveedor.SelectedValue = productoSeleccionado.ID_Proveedor;
            }
        }

        private void CargarProveedores()
        {
            List<Proveedor> listaproveedores = proveedores.ObtenerTodosLosProveedores();
            comboBoxProveedor.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
            comboBoxProveedor.ValueMember = "ID_Proveedor"; // Indica la propiedad que se utilizará como valor seleccionado
            comboBoxProveedor.DataSource = listaproveedores;
            // Habilitamos el autocompletado
            comboBoxProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarCategorias()
        {
            // Llamamos al método para obtener todas las categorías
            List<Categoria_Producto> listacategorias = categorias.ObtenerTodasLasCategorias_Producto();
            // Configuramos el ComboBox
            comboBoxCategoria.DisplayMember = "Categoria"; // Indica la propiedad que se mostrará en el ComboBox
            comboBoxCategoria.ValueMember = "ID_Categoria"; // Indica la propiedad que se utilizará como valor seleccionado
            // Establecemos la lista de categorías como origen de datos del ComboBox
            comboBoxCategoria.DataSource = listacategorias;

            // Habilitamos el autocompletado
            comboBoxCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarTipo()
        {
            List<Tipo_Producto> listatipos = tipos.ObtenerTodosLosTipos_Producto();
            comboBoxTipo.DisplayMember = "Tipo"; // Indica la propiedad que se mostrará en el ComboBox
            comboBoxTipo.ValueMember = "ID_Tipo"; // Indica la propiedad que se utilizará como valor seleccionado
            comboBoxTipo.DataSource = listatipos;
            // Habilitamos el autocompletado
            comboBoxTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Crear un objeto Producto con la información ingresada en el formulario
                Producto producto = new Producto
                {
                    Nombre = textBoxNombre.Text,
                    Existencias = int.Parse(textBoxExistencias.Text),
                    PrecioVenta = decimal.Parse(textBoxPrecioVenta.Text),
                    StockMinimo = int.Parse(textBoxStockMinimo.Text),
                    ID_Categoria = ((Categoria_Producto)comboBoxCategoria.SelectedItem).ID_Categoria, // Suponiendo que tienes una clase Categoria_Producto con ID_Categoria y Categoria
                    ID_Proveedor = ((Proveedor)comboBoxProveedor.SelectedItem).ID_Proveedor, // Suponiendo que tienes una clase Proveedor con ID_Proveedor y Nombre
                    ID_Tipo = ((Tipo_Producto)comboBoxTipo.SelectedItem).ID_Tipo, // Suponiendo que tienes una clase Tipo con ID_Tipo y Nombre
                    Habilitado = checkBoxHabilitado.Checked
                };
                if (modo == 1)
                {
                    // Intentar realizar el alta del producto
                    try
                    {
                        int resultado = productos.AltaProducto(producto);

                        if (resultado > 0)
                        {
                            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos(); // Limpiar los campos después de agregar el producto
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (modo == 2)
                {
                    try
                    {
                        int resultado = productos.ModificarProducto(producto, idProductoSeleccionado);

                        if (resultado > 0)
                        {
                            MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario
            textBoxNombre.Text = "";
            textBoxExistencias.Text = "";
            textBoxPrecioVenta.Text = "";
            textBoxStockMinimo.Text = "";
            comboBoxCategoria.SelectedIndex = -1;
            comboBoxProveedor.SelectedIndex = -1;
            comboBoxTipo.SelectedIndex = -1;
            checkBoxHabilitado.Checked = false;
        }

        private bool ValidarCampos()
        {
            // Verificar que el campo Nombre no esté vacío
            if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                MessageBox.Show("Por favor ingresa un nombre.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que el campo Existencias no esté vacío y sea un número entero válido
            int existencias;
            if (!int.TryParse(textBoxExistencias.Text, out existencias))
            {
                MessageBox.Show("Por favor ingresa un valor válido para las existencias.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que el campo PrecioVenta no esté vacío y sea un número decimal válido
            decimal precioVenta;
            if (!decimal.TryParse(textBoxPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("Por favor ingresa un valor válido para el precio de venta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que el campo StockMinimo no esté vacío y sea un número entero válido
            int stockMinimo;
            if (!int.TryParse(textBoxStockMinimo.Text, out stockMinimo))
            {
                MessageBox.Show("Por favor ingresa un valor válido para el stock mínimo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que se haya seleccionado una categoría
            if (comboBoxCategoria.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona una categoría.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que se haya seleccionado un proveedor
            if (comboBoxProveedor.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un proveedor.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verificar que se haya seleccionado un tipo
            if (comboBoxTipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un tipo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Si todos los campos están validados correctamente, retornar true
            return true;
        }
    }
}
