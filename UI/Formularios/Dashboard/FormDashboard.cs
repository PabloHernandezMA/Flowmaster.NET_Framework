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
using System.Windows.Forms.DataVisualization.Charting;

namespace UI.Formularios.Dashboard
{
    public partial class FormDashboard : Form
    {
        private static FormDashboard instance;

        // Constructor privado para evitar la creación de instancias fuera de la clase
        private FormDashboard()
        {
            InitializeComponent();
        }

        // Método estático para obtener la instancia única del formulario
        public static FormDashboard GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormDashboard();
            }
            return instance;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            dateTimePickerFechaFin.Value = DateTime.Now;
            dateTimePickerFechaInicio.Value = DateTime.Now;
            dateTimePickerFechaInicio.MaxDate = DateTime.Now;
            dateTimePickerFechaInicio.ValueChanged += DateTimePickerFecha_ValueChanged;
            dateTimePickerFechaFin.ValueChanged += DateTimePickerFecha_ValueChanged;
            button30Dias.PerformClick();
            cargarGridViewProductosSinStock();
            cargarTarjetasDePedidos();
            CargarDatosEnChart();
        }

        private void button7Dias_Click(object sender, EventArgs e)
        {
            dateTimePickerFechaInicio.Value = DateTime.Today.AddDays(-7);
            dateTimePickerFechaFin.Value = DateTime.Now;
        }

        private void button30Dias_Click(object sender, EventArgs e)
        {
            dateTimePickerFechaInicio.Value = DateTime.Today.AddDays(-30);
            dateTimePickerFechaFin.Value = DateTime.Now;
        }

        private void button365Dias_Click(object sender, EventArgs e)
        {
            dateTimePickerFechaInicio.Value = DateTime.Today.AddDays(-365);
            dateTimePickerFechaFin.Value = DateTime.Now;
        }

        private void cargarGridViewProductosSinStock()
        {

        }

        private void cargarTarjetasDePedidos()
        {
            labelPedidosPendientes.Text = CN_Pedidos.ObtenerInstancia().ObtenerCantidadPedidosPendientes(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value).ToString();
        }

        private void DateTimePickerFecha_ValueChanged(object sender, EventArgs e)
        {
            // Método para manejar el cambio de valor de los dateTimePicker
            cargarTarjetasDePedidos();
        }


        private string NombreMes(int numeroMes)
        {
            return new DateTime(2024, numeroMes, 1).ToString("MMMM");
        }

        private void CargarDatosEnChart()
        {
            // Obtener la lista de todos los pedidos
            List<Pedido> listaPedidos = CN_Pedidos.ObtenerInstancia().ObtenerTodosLosPedidos();

            // Crear un diccionario para almacenar la cantidad de pedidos por mes
            Dictionary<int, int> cantidadPedidosPorMes = new Dictionary<int, int>();

            // Inicializar el diccionario con ceros para cada mes
            for (int i = 1; i <= 12; i++)
            {
                cantidadPedidosPorMes.Add(i, 0);
            }

            // Contar la cantidad de pedidos por mes
            foreach (Pedido pedido in listaPedidos)
            {
                int mes = pedido.FechaInicio.Month;
                cantidadPedidosPorMes[mes]++;
            }

            // Limpiar los puntos existentes en el gráfico
            chartBars.Series["Pedidos"].Points.Clear();

            // Agregar los datos al gráfico de barras
            foreach (var kvp in cantidadPedidosPorMes)
            {
                // Agregar el punto al gráfico con el nombre del mes y la cantidad de pedidos
                DataPoint point = new DataPoint(); // Crear un nuevo punto
                point.SetValueXY(NombreMes(kvp.Key), kvp.Value); // Establecer los valores X e Y del punto
                point.Label = kvp.Value.ToString(); // Establecer la etiqueta del punto como la cantidad de pedidos
                point.LabelForeColor = Color.White;
                chartBars.Series["Pedidos"].Points.Add(point); // Agregar el punto al gráfico
            }
        }
    }
}
