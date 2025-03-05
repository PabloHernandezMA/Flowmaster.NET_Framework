using Dominio;
using Dominio.Aplicacion;
using Modelo;
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
            cargarTarjetasDePedidos();
            CargarDatosEnChart();
            CargarProyectos();
        }

        private void cargarTarjetasDePedidos()
        {
            labelPedidosPendientes.Text = CN_Pedidos.ObtenerInstancia().ObtenerCantidadPedidosPendientes(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value).ToString();
            labelPedidosAsignados.Text = CN_Pedidos.ObtenerInstancia().ObtenerCantidadPedidosAsignados(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value).ToString();
            labelPedidosEnProceso.Text = CN_Pedidos.ObtenerInstancia().ObtenerCantidadPedidosEnProceso(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value).ToString();
            labelPedidosCompletados.Text = CN_Pedidos.ObtenerInstancia().ObtenerCantidadPedidosCompletados(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value).ToString();
            labelMisPedidosPendientes.Text = CN_Pedidos.ObtenerInstancia().ObtenerCantidadMisPedidosPendientes(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value).ToString();
        }

        private void DateTimePickerFecha_ValueChanged(object sender, EventArgs e)
        {
            // Método para manejar el cambio de valor de los dateTimePicker
            cargarTarjetasDePedidos();
            CargarDatosEnChart();
            CargarProyectos();
        }


        private string NombreMes(int numeroMes)
        {
            return new DateTime(2024, numeroMes, 1).ToString("MMMM");
        }

        private void CargarDatosEnChart()
        {
            // Obtener la lista de todos los pedidos
            List<Pedido> listaPedidos = CN_Pedidos.ObtenerInstancia().ObtenerTodosLosPedidos();

            // Obtener las fechas de los DateTimePicker
            DateTime fechaInicio = dateTimePickerFechaInicio.Value;
            DateTime fechaFin = dateTimePickerFechaFin.Value;

            // Filtrar la lista de pedidos según la FechaInicio
            var pedidosFiltrados = listaPedidos
                .Where(p => p.FechaInicio >= fechaInicio && p.FechaInicio <= fechaFin)
                .ToList();

            // Crear un diccionario para almacenar la cantidad de pedidos
            Dictionary<string, int> cantidadPedidos = new Dictionary<string, int>();

            // Determinar si las fechas abarcan años distintos
            bool diferentesAños = fechaInicio.Year != fechaFin.Year;

            // Contar la cantidad de pedidos por mes o por año
            foreach (Pedido pedido in pedidosFiltrados)
            {
                string clave;
                if (diferentesAños)
                {
                    // Usar el año como clave
                    clave = pedido.FechaInicio.Year.ToString();
                }
                else
                {
                    // Usar el mes y el año como clave
                    clave = $"{pedido.FechaInicio.Year}-{pedido.FechaInicio.Month}";
                }

                if (!cantidadPedidos.ContainsKey(clave))
                {
                    cantidadPedidos[clave] = 0;
                }
                cantidadPedidos[clave]++;
            }

            // Limpiar los puntos existentes en el gráfico
            chartBarsP1.Series["Pedidos"].Points.Clear();

            // Agregar los datos al gráfico de barras
            foreach (var kvp in cantidadPedidos)
            {
                // Agregar el punto al gráfico con la clave (año o mes-año) y la cantidad de pedidos
                DataPoint point = new DataPoint(); // Crear un nuevo punto
                point.SetValueXY(diferentesAños ? kvp.Key : NombreMes(int.Parse(kvp.Key.Split('-')[1])), kvp.Value); // Establecer los valores X e Y del punto
                point.Label = kvp.Value.ToString(); // Establecer la etiqueta del punto como la cantidad de pedidos
                point.LabelForeColor = Color.White;
                chartBarsP1.Series["Pedidos"].Points.Add(point); // Agregar el punto al gráfico
            }
        }

        private void CargarProyectos()
        {
            // Obtener todos los proyectos
            List<Proyecto> proyectos = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosProyectos();
            Usuario usuarioEnSesion = CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario();
            List<Empleado> empleados = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            Empleado empleadoEnSesion = empleados.FirstOrDefault(e => e.ID_User == usuarioEnSesion.ID_User);
            List<Proyecto> proyectosDelEmpleado = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosProyectosEnLosQueParticipaUnEmpleado(empleadoEnSesion.ID_Empleado);
            List<Proyecto> misProyectos = CN_Proyectos.ObtenerInstancia().ObtenerTodosLosProyectosEnLosQueParticipaUnEmpleado(empleadoEnSesion.ID_Empleado);
            labelProyectosProgreso.Text = misProyectos.Where(p => p.Estado == "En proceso").ToList().Count().ToString();
            

            // Obtener las fechas de los DateTimePicker
            DateTime fechaInicio = dateTimePickerFechaInicio.Value;
            DateTime fechaFin = dateTimePickerFechaFin.Value;

            // Filtrar los proyectos según las fechas
            var proyectosFiltrados = proyectos
                .Where(p => p.FechaInicio >= fechaInicio && p.FechaFin <= fechaFin)
                .ToList();

            // Agrupar los proyectos filtrados por su estado
            var proyectosAgrupados = proyectosFiltrados
                .GroupBy(p => p.Estado)
                .Select(g => new
                {
                    Estado = g.Key,
                    Cantidad = g.Count()
                }).ToList();

            // Limpiar la serie existente
            chartEstadoProyectos.Series["Series1"].Points.Clear();

            // Agregar los datos agrupados a la serie existente
            foreach (var grupo in proyectosAgrupados)
            {
                chartEstadoProyectos.Series["Series1"].Points.AddXY(grupo.Estado, grupo.Cantidad);
            }
        }
    }
}
