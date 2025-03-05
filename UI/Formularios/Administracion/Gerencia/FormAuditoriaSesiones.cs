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
    public partial class FormAuditoriaSesiones : Form
    {
        private Empleado empleado;
        public FormAuditoriaSesiones()
        {
            InitializeComponent();
        }

        private void FormAuditoriaSesiones_Load(object sender, EventArgs e)
        {
            CargarComboBoxEmpleados();
            empleado = CN_Empleados.ObtenerInstancia().ObtenerEmpleadoPorIdUsuario(CN_UsuarioEnSesion.ObtenerInstancia().ObtenerUsuario().ID_User);
        }
        private void CargarComboBoxEmpleados()
        {
            List<Empleado> empleados = CN_Empleados.ObtenerInstancia().ObtenerTodosLosEmpleados();
            var empleadosHabilitados = empleados.Where(e => e.Habilitado).ToList();
            comboBoxEmpleado.DataSource = empleadosHabilitados;
            comboBoxEmpleado.ValueMember = "ID_Empleado";
            comboBoxEmpleado.DisplayMember = "Nombre";
            comboBoxEmpleado.Text = "Todos";
        }

        private void checkBoxEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEmpleado.Checked) { comboBoxEmpleado.Enabled = true; }
            else { comboBoxEmpleado.Enabled = false; comboBoxEmpleado.Text = "Todos"; }
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            List<> datosReporte = ;
            if (datosReporte == null || datosReporte.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            reportViewerSesionesBindingSource.DataSource = datosReporte;
            this.reportViewerSesiones.LocalReport.SetParameters(new ReportParameter("ReportParameterEmpleado", empleado.Nombre));
            this.reportViewerSesiones.LocalReport.SetParameters(new ReportParameter("ReportParameterFechaInicio", dateTimePickerFechaInicio.Value.ToString("yyyy-MM-dd")));
            this.reportViewerSesiones.LocalReport.SetParameters(new ReportParameter("ReportParameterFechaFin", dateTimePickerFechaFin.Value.ToString("yyyy-MM-dd")));
            this.reportViewerSesiones.LocalReport.DataSources.Clear();
            this.reportViewerSesiones.LocalReport.DataSources.Add(new ReportDataSource("DataSetTareas", reportViewerTareasBindingSource));
            this.reportViewerSesiones.RefreshReport();
        }
    }
}
