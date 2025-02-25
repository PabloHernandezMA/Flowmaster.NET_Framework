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
using Microsoft.Reporting.WinForms;

namespace UI.Formularios.Administracion.Gerencia
{
    public partial class FormReporteProyectos : Form
    {
        public FormReporteProyectos()
        {
            InitializeComponent();
        }
        private void FormReporteProyectos_Load(object sender, EventArgs e)
        {
            comboBoxEstadoProyecto.Text = "En proceso";
        }

        private void buttonGenerar_Click_1(object sender, EventArgs e)
        {
            DateTime fechaDesde = dateTimePickerFechaInicio.Value;
            string estado = comboBoxEstadoProyecto.SelectedItem?.ToString() ?? "";

            List<ReporteProyectosProgreso> datosReporte = CN_Proyectos.ObtenerInstancia().ObtenerProgresoProyectos(fechaDesde, estado);

            if (datosReporte == null || datosReporte.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reporteProyectosProgresoBindingSource.DataSource = datosReporte;
            // Establecer el parámetro para el estado
            reportViewerProyectos.LocalReport.SetParameters(new ReportParameter("Estado", estado));

            // Refrescar el ReportViewer
            this.reportViewerProyectos.RefreshReport();
        }
    }
}
