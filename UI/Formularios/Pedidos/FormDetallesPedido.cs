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
using UI.Formularios.Administracion.Clientes;
using UI.Formularios.Administracion.Empleados;

namespace UI.Formularios.Pedidos
{
    public partial class FormDetallesPedido : Form
    {
        private int modo; // 0 = Ver    1 = Agregar     2 = Modificar
        private int idPedidoSeleccionado;
        private CN_Productos productos;
        private CN_Pedidos pedidos;
        private Pedido pedidoSeleccionado;
        private int idClienteSeleccionado;
        private int idEmpleadoSeleccionado;
        private List<Empleado> listaEmpleados;
        // Instancia estática privada para almacenar la única instancia de FormDetallesPedido.
        private static FormDetallesPedido instancia;

        private FormDetallesPedido(int modo)
        {
            InitializeComponent();
            this.modo = modo;
        }
        private FormDetallesPedido(int idPedidoSeleccionado, int modo)
        {
            InitializeComponent();
            this.modo = modo;
            this.idPedidoSeleccionado = idPedidoSeleccionado;
        }

        // Método estático para obtener la instancia única de FormDetallesPedido.
        public static FormDetallesPedido ObtenerInstancia(int modo)
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormDetallesPedido(modo);
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }
        public static FormDetallesPedido ObtenerInstancia(int idPedidoSeleccionado, int modo)
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormDetallesPedido(idPedidoSeleccionado, modo);
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        private void FormDetallesPedido_Load(object sender, EventArgs e)
        {
            productos = CN_Productos.ObtenerInstancia();
            pedidos = CN_Pedidos.ObtenerInstancia();
            CargarAreas();
            CargarModo();
            LlenarCampos();
            CargarSucursales();
        }

       private void CargarAreas()
        {
                List<Area> listaAreas = CN_Areas.ObtenerInstancia().ObtenerTodasLasAreas();
                comboBoxArea.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
                comboBoxArea.ValueMember = "ID_Area"; // Indica la propiedad que se utilizará como valor seleccionado
                comboBoxArea.DataSource = listaAreas;
                // Habilitamos el autocompletado
                comboBoxArea.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxArea.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarSucursales()
        {
            if (textBoxCliente.Text != "")
            {
                List<Sucursal> listaTodasLasSucrusales = CN_Sucursales.ObtenerInstancia().ObtenerTodasLasSucursales();
                List<Sucursal> listasucrusales = CN_Sucursales.ObtenerInstancia().ObtenerSucursalesPorIDCliente(pedidoSeleccionado.ID_Cliente);
                comboBoxSucursal.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
                comboBoxSucursal.ValueMember = "ID_Sucursal"; // Indica la propiedad que se utilizará como valor seleccionado
                comboBoxSucursal.DataSource = listasucrusales;
                // Habilitamos el autocompletado
                comboBoxSucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxSucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBoxSucursal.SelectedValue = pedidoSeleccionado.ID_Sucursal;
            }
            
        }

        private void CargarModo()
        {
            if (modo == 0) //Ver
            {
                pedidoSeleccionado = pedidos.ObtenerTodosLosPedidos().FirstOrDefault(p => p.ID_Pedido== idPedidoSeleccionado);
                buttonCancelar.Visible = false;
                buttonGuardar.Visible = false;
            }
            if (modo == 1) //Agregar
            {
                checkBoxEnProceso.Enabled = false;
                checkBoxCancelado.Enabled = false;
                checkBoxCerrado.Enabled = false;
            }
            if (modo == 2) //Modificar
            {
                pedidoSeleccionado = pedidos.ObtenerTodosLosPedidos().FirstOrDefault(p => p.ID_Pedido == idPedidoSeleccionado);
            }
        }
        private void LlenarCampos()
        {
            if (pedidoSeleccionado != null)
            {
                listaEmpleados = CN_Empleados.ObtenerInstancia().ObtenerEmpleadosAsociadosAPedido(pedidoSeleccionado.ID_Pedido);
                labelNumeroID.Text = pedidoSeleccionado.ID_Pedido.ToString();
                textBoxCliente.Text = CN_Clientes.ObtenerInstancia().ObtenerClientePorIDCliente(pedidoSeleccionado.ID_Cliente)[0].Nombre;
                //comboBoxSucursal.SelectedValue = pedidoSeleccionado.ID_Sucursal;
                comboBoxArea.SelectedValue = pedidoSeleccionado.ID_Area;
                textBoxIngresoPedido.Text = pedidoSeleccionado.DescripcionSolicitud;
                labelEstado.Text = CN_EstadosPedido.ObtenerInstancia().ObtenerEstadosPedidosPorIDPedido(idPedidoSeleccionado)[0].Estado;
                dataGridViewEmpleados.DataSource = listaEmpleados;
                textBoxAtencionPedido.Text = pedidoSeleccionado.DescripcionTareasRealizadas;
                dataGridViewProductos.DataSource = CN_DetallesPedido.ObtenerInstancia().ObtenerDetallesPedidoPorIDPedido(idPedidoSeleccionado);
                dateTimePickerIngreso.Value = pedidoSeleccionado.FechaInicio;
                dateTimePickerCierre.Value = pedidoSeleccionado.FechaFin;
                labelTotal.Text = pedidoSeleccionado.TotalPedido.ToString();
            }
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario GestionarClientes
            FormGestionarClientes formGestionarClientes = new FormGestionarClientes();

            // Mostrar el formulario GestionarClientes como un diálogo modal
            DialogResult resultado = formGestionarClientes.ShowDialog();

            // Verificar si se ha seleccionado un cliente y el resultado es OK
            if (resultado == DialogResult.OK)
            {
                // Obtener el ID_Cliente seleccionado del formulario GestionarClientes
                idClienteSeleccionado = formGestionarClientes.ObtenerIDClienteSeleccionado();
                textBoxCliente.Text = CN_Clientes.ObtenerInstancia().ObtenerClientePorIDCliente(idClienteSeleccionado)[0].Nombre;
                CargarNuevasSucursales();
                comboBoxSucursal.SelectedValue = 0;
            }
        }

        private void CargarNuevasSucursales()
        {
            List<Sucursal> listasucurusales = CN_Sucursales.ObtenerInstancia().ObtenerSucursalesPorIDCliente(idClienteSeleccionado);
            comboBoxSucursal.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
            comboBoxSucursal.ValueMember = "ID_Sucursal"; // Indica la propiedad que se utilizará como valor seleccionado
            comboBoxSucursal.DataSource = listasucurusales;
            // Habilitamos el autocompletado
            comboBoxSucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxSucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void buttonAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario GestionarClientes
            FormGestionarEmpleados formGestionarEmpleados = new FormGestionarEmpleados();

            // Mostrar el formulario GestionarClientes como un diálogo modal
            DialogResult resultado = formGestionarEmpleados.ShowDialog();

            // Verificar si se ha seleccionado un cliente y el resultado es OK
            if (resultado == DialogResult.OK)
            {
                // Obtener el ID_Cliente seleccionado del formulario GestionarClientes
                idEmpleadoSeleccionado = formGestionarEmpleados.ObtenerIDEmpleadoSeleccionado();
                listaEmpleados.Add(CN_Empleados.ObtenerInstancia().ObtenerEmpleadosPorIDEmpleado(idEmpleadoSeleccionado)[0]);
                dataGridViewEmpleados.DataSource = null;
                dataGridViewEmpleados.DataSource = listaEmpleados;
            }
        }

        private void buttonEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                int idSeleccion = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["ID_Empleado"].Value);
                // Remover el empleado de la lista
                listaEmpleados.RemoveAll(empleado => empleado.ID_Empleado == idSeleccion);

                // Refrescar el DataGridView
                dataGridViewEmpleados.DataSource = null;
                dataGridViewEmpleados.DataSource = listaEmpleados;

            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado primero.");
            }
        }
    }
}
