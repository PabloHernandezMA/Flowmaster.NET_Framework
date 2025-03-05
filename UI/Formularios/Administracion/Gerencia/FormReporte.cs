using Dominio.Aplicacion;
using Dominio.Seguridad;
using Microsoft.Reporting.WinForms;
using Modelo.Aplicacion;
using Modelo.Seguridad;
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
            comboBoxEmpleado.DisplayMember = "Nombre"; // Indica la propiedad que se mostrará en el ComboBox
            comboBoxEmpleado.ValueMember = "ID_Empleado"; // Indica la propiedad que se utilizará como valor seleccionado
            comboBoxEmpleado.DataSource = listaEmpleado;
            // Habilitamos el autocompletado
            comboBoxEmpleado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxEmpleado.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Pedido> listaPedidos = CN_Pedidos.ObtenerInstancia().ObtenerTodosLosPedidosPorIDEmpleado(Convert.ToInt32(comboBoxEmpleado.SelectedValue));
            DateTime fechaInicio = dateTimePickerInicio.Value;
            DateTime fechaFin = dateTimePickerFin.Value;

            // Filtrar la lista de pedidos según las fechas seleccionadas
            List<Pedido> listaPedidosFiltrada = listaPedidos.Where(pedido => pedido.FechaInicio >= fechaInicio && pedido.FechaInicio <= fechaFin).ToList();
            
            if (listaPedidosFiltrada == null || listaPedidosFiltrada.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bindingSourcePedidos.DataSource = listaPedidosFiltrada;
            this.reportViewerPedidos.LocalReport.SetParameters(new ReportParameter("ReportParameterEmpleado", comboBoxEmpleado.Text));
            this.reportViewerPedidos.LocalReport.SetParameters(new ReportParameter("ReportParameterFechaInicio", dateTimePickerInicio.Value.ToString("yyyy-MM-dd")));
            this.reportViewerPedidos.LocalReport.SetParameters(new ReportParameter("ReportParameterFechaFin", dateTimePickerFin.Value.ToString("yyyy-MM-dd")));
            this.reportViewerPedidos.LocalReport.DataSources.Clear();
            this.reportViewerPedidos.LocalReport.DataSources.Add(new ReportDataSource("DataSetPedidos", bindingSourcePedidos));
            this.reportViewerPedidos.RefreshReport();
        }
    }
}
