using Dominio.Aplicacion;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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

namespace UI.Formularios.Administracion.Gerencia
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            List<Empleado> listaEmpleado = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            comboBox1.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
            comboBox1.ValueMember = "ID_Empleado"; // Indica la propiedad que se utilizará como valor seleccionado
            comboBox1.DataSource = listaEmpleado;
            // Habilitamos el autocompletado
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pedido> listaPedidos = CN_Pedidos.ObtenerInstancia().ObtenerTodosLosPedidosPorIDEmpleado(Convert.ToInt32(comboBox1.SelectedValue));
                DateTime fechaInicio = dateTimePickerInicio.Value;
                DateTime fechaFin = dateTimePickerFin.Value;

                // Filtrar la lista de pedidos según las fechas seleccionadas
                List<Pedido> listaPedidosFiltrada = listaPedidos.Where(pedido => pedido.FechaInicio >= fechaInicio && pedido.FechaFin <= fechaFin).ToList();
                GenerarReporte(listaPedidosFiltrada, fechaInicio,fechaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GenerarReporte(List<Pedido> listaPedidosFiltrada, DateTime fechaInicio, DateTime fechaFin)
        {
            // Mostrar el diálogo de guardado de archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar Reporte PDF";
            saveFileDialog.ShowDialog();

            // Verificar si se seleccionó una ubicación válida
            if (saveFileDialog.FileName != "")
            {
                string rutaArchivo = saveFileDialog.FileName;

                // Crear un nuevo documento PDF
                PdfDocument pdf = new PdfDocument(new PdfWriter(rutaArchivo));
                Document documento = new Document(pdf);

                // Agregar título
                Paragraph titulo = new Paragraph("Reporte de Pedidos asignados a un usuario").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20);
                documento.Add(titulo);

                // Agregar rango de fechas
                Paragraph rangoFechas = new Paragraph($"Fecha de inicio: {fechaInicio.ToShortDateString()} - Fecha de fin: {fechaFin.ToShortDateString()}");
                documento.Add(rangoFechas);

                // Agregar tabla de pedidos
                Table tablaPedidos = new Table(4).UseAllAvailableWidth();
                tablaPedidos.AddHeaderCell("ID Pedido");
                tablaPedidos.AddHeaderCell("Cliente");
                tablaPedidos.AddHeaderCell("Sucursal");
                tablaPedidos.AddHeaderCell("Estado");

                foreach (Pedido pedido in listaPedidosFiltrada)
                {
                    tablaPedidos.AddCell(pedido.ID_Pedido.ToString());
                    tablaPedidos.AddCell("Cliente A");
                    tablaPedidos.AddCell(pedido.ID_Sucursal.ToString());
                    tablaPedidos.AddCell("Asignado");
                }

                documento.Add(tablaPedidos);

                // Cerrar documento
                documento.Close();
            }
        }
}
}
