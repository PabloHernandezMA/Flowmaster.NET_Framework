using Dominio.Aplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UI.Formularios.Administracion.Clientes;
using UI.Formularios.Administracion.Empleados;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
        private List<DetallePedido> listaProductos;
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
                listaProductos = CN_DetallesPedido.ObtenerInstancia().ObtenerDetallesPedidoPorIDPedido(idPedidoSeleccionado);
                labelNumeroID.Text = pedidoSeleccionado.ID_Pedido.ToString();
                textBoxCliente.Text = CN_Clientes.ObtenerInstancia().ObtenerClientePorIDCliente(pedidoSeleccionado.ID_Cliente)[0].Nombre;
                //comboBoxSucursal.SelectedValue = pedidoSeleccionado.ID_Sucursal;
                comboBoxArea.SelectedValue = pedidoSeleccionado.ID_Area;
                textBoxIngresoPedido.Text = pedidoSeleccionado.DescripcionSolicitud;
                labelEstado.Text = CN_EstadosPedido.ObtenerInstancia().ObtenerEstadosPedidosPorIDPedido(idPedidoSeleccionado)[0].Estado;
                dataGridViewEmpleados.DataSource = listaEmpleados;
                textBoxAtencionPedido.Text = pedidoSeleccionado.DescripcionTareasRealizadas;
                dataGridViewProductos.DataSource = listaProductos;
                dateTimePickerIngreso.Value = pedidoSeleccionado.FechaInicio;
                dateTimePickerCierre.Value = pedidoSeleccionado.FechaFin;
                labelTotal.Text = pedidoSeleccionado.TotalPedido.ToString();
                calcularTotal();
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
                labelEstado.Text = "Asignado";
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
                if (dataGridViewEmpleados.RowCount == 0)
                {
                 labelEstado.Text = "Asignado";
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado primero.");
            }
        }

        private void buttonAgregarProducto_Click(object sender, EventArgs e)
        {
            // Abre el formulario FormDetalleProductoPedido
            FormDetalleProductoPedido formDetalle = new FormDetalleProductoPedido(idPedidoSeleccionado);
            formDetalle.FormClosed += (s, ev) =>
            {
                if (formDetalle.DetallePedidoCreado != null)
                {
                    // Procesa el objeto DetallePedido recibido después de cerrar el formulario FormDetalleProductoPedido
                    DetallePedido detallePedido = formDetalle.DetallePedidoCreado;
                    listaProductos.Add(detallePedido);
                    dataGridViewProductos.DataSource = null;
                    dataGridViewProductos.DataSource = listaProductos;
                    calcularTotal();
                }
            };
            formDetalle.ShowDialog(); // Abre el formulario como diálogo modal
        }

        private void buttonEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                int idSeleccion = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID_Producto"].Value);
                // Remover el empleado de la lista
                listaProductos.RemoveAll(producto => producto.ID_Producto == idSeleccion);

                // Refrescar el DataGridView
                dataGridViewProductos.DataSource = null;
                dataGridViewProductos.DataSource = listaProductos;
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado primero.");
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;

            // Iterar a través de las filas del DataGridViewProductos
            foreach (DataGridViewRow fila in dataGridViewProductos.Rows)
            {
                // Obtener el valor de TotalDetalle de la fila actual y sumarlo al total
                total += Convert.ToDecimal(fila.Cells["TotalDetalle"].Value);
            }

            // Mostrar el total calculado en labelTotal.Text
            labelTotal.Text = total.ToString();
        }

        private void checkBoxEnProceso_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnProceso.Checked)
            {
                labelEstado.Text = "En proceso";
                TabPage tabPage = tabControl1.TabPages[1]; // Obtén la pestaña deseada (0-indexada)

                foreach (Control control in tabPage.Controls)
                {
                    control.Enabled = false;
                }
            }
            else
            {
                labelEstado.Text = "Asignado";
                TabPage tabPage = tabControl1.TabPages[1]; // Obtén la pestaña deseada (0-indexada)

                foreach (Control control in tabPage.Controls)
                {
                    control.Enabled = true;
                }
            }
        }

        private void checkBoxCancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCancelado.Checked)
            {
                labelEstado.Text = "Cancelado";
                TabPage tabPage = tabControl1.TabPages[2]; // Obtén la pestaña deseada (0-indexada)

                foreach (Control control in tabPage.Controls)
                {
                    control.Enabled = false;
                }
            }
            else
            {
                labelEstado.Text = "En proceso";
                TabPage tabPage = tabControl1.TabPages[2]; // Obtén la pestaña deseada (0-indexada)

                foreach (Control control in tabPage.Controls)
                {
                    control.Enabled = true;
                }
            }
        }

        private void checkBoxCerrado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCerrado.Checked && !checkBoxCancelado.Checked)
            {
                labelEstado.Text = "Cerrado";
            }
            if (checkBoxCerrado.Checked && checkBoxCancelado.Checked)
            {
                labelEstado.Text = "Cancelado";
            }
        }

        private void buttonVerFactura_Click(object sender, EventArgs e)
        {
            // Crear un nuevo documento PDF
            Document doc = new Document();

            // Ruta donde se guardará el PDF
            string filePath = "Factura.pdf";

            // Crear un objeto PdfWriter para escribir en el documento
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Abrir el documento
            doc.Open();

            // Añadir contenido al documento
            doc.Add(new Paragraph($"Número de pedido: {labelNumeroID.Text}"));
            doc.Add(new Paragraph($"Cliente: {textBoxCliente.Text}"));
            doc.Add(new Paragraph($"Sucursal: {comboBoxSucursal.SelectedValue}"));
            doc.Add(new Paragraph($"Área: {comboBoxArea.SelectedValue}"));
            doc.Add(new Paragraph($"Solicitud del cliente: {textBoxIngresoPedido.Text}"));
            doc.Add(new Paragraph($"Atención brindada: {textBoxAtencionPedido.Text}"));
            doc.Add(new Paragraph($"Fecha de ingreso: {dateTimePickerIngreso.Value}"));
            doc.Add(new Paragraph($"Fecha de cierre: {dateTimePickerCierre.Value}"));
            doc.Add(new Paragraph($"Total: {labelTotal.Text}"));

            // Agregar empleados
            if (dataGridViewEmpleados.DataSource != null)
            {
                List<Empleado> empleados = (List<Empleado>)dataGridViewEmpleados.DataSource;
                doc.Add(new Paragraph("Empleados:"));
                foreach (Empleado empleado in empleados)
                {
                    doc.Add(new Paragraph($"- ID: {empleado.ID_Empleado}, Nombre: {empleado.Nombre}, Área: {empleado.ID_Area}"));
                }
            }

            // Agregar productos y servicios brindados
            if (dataGridViewProductos.DataSource != null)
            {
                List<DetallePedido> detallesPedido = (List<DetallePedido>)dataGridViewProductos.DataSource;
                doc.Add(new Paragraph("Productos y servicios brindados:"));
                foreach (DetallePedido detalle in detallesPedido)
                {
                    doc.Add(new Paragraph($"- ID Producto: {detalle.ID_Producto}, Cantidad: {detalle.Cantidad}, Total Detalle: {detalle.TotalDetalle}, Precio Unitario: {detalle.PrecioUnitario}"));
                }
            }

            // Cerrar el documento
            doc.Close();

            // Mostrar un mensaje de éxito
            MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
