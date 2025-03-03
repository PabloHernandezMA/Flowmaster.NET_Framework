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
using Dominio;

namespace UI.Formularios.Administracion.Gerencia
{
    public partial class FormAuditoriaTareas: Form
    {
        private Empleado empleado;
        public FormAuditoriaTareas()
        {
            InitializeComponent();
        }

        private void FormAuditoriaTareas_Load(object sender, EventArgs e)
        {
            empleado = CN_Empleados.ObtenerInstancia().ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User);
            //this.reportViewerTareas.LocalReport.DataSources.Clear();
            //this.reportViewerTareas.LocalReport.DataSources.Add(new ReportDataSource("DataSetTareas", reportViewerTareasBindingSource));
            //this.reportViewerTareas.RefreshReport();
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            List<AuditoriaTareaTarjeta> datosReporte = CN_Auditorias.ObtenerInstancia().ObtenerAuditoriaTareas(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value);
            if (datosReporte == null || datosReporte.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            reportViewerTareasBindingSource.DataSource = datosReporte;
            this.reportViewerTareas.LocalReport.SetParameters(new ReportParameter("ReportParameterEmpleado", empleado.Nombre));
            this.reportViewerTareas.LocalReport.SetParameters(new ReportParameter("ReportParameterFechaInicio", dateTimePickerFechaInicio.Value.ToString("yyyy-MM-dd")));
            this.reportViewerTareas.LocalReport.SetParameters(new ReportParameter("ReportParameterFechaFin", dateTimePickerFechaFin.Value.ToString("yyyy-MM-dd")));
            this.reportViewerTareas.LocalReport.DataSources.Clear();
            this.reportViewerTareas.LocalReport.DataSources.Add(new ReportDataSource("DataSetTareas", reportViewerTareasBindingSource));
            this.reportViewerTareas.RefreshReport();
        }
    }
}
