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
using Modelo.Seguridad;
using Dominio.Seguridad;
using ClosedXML.Excel;

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
            comboBoxEmpleado.ValueMember = "ID_User";
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
            List<AuditoriaSesiones> datosReporte;
            if (checkBoxEmpleado.Checked)
            {
                datosReporte = CN_AuditoriaSesiones.ObtenerInstancia().ObtenerAuditoriaSesionesPorFechaYUsuario(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value, (int)comboBoxEmpleado.SelectedValue);  
            }
            else
            {
                datosReporte = CN_AuditoriaSesiones.ObtenerInstancia().ObtenerAuditoriaSesionesPorFecha(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value);
            }
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
            this.reportViewerSesiones.LocalReport.DataSources.Add(new ReportDataSource("DataSetSesiones", reportViewerSesionesBindingSource));
            this.reportViewerSesiones.RefreshReport();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            // Obtener los datos del reporte
            List<AuditoriaSesiones> datosReporte;
            string nombreEmpleado = "Todos"; // Por defecto, si no se filtra por empleado

            if (checkBoxEmpleado.Checked)
            {
                datosReporte = CN_AuditoriaSesiones.ObtenerInstancia()
                    .ObtenerAuditoriaSesionesPorFechaYUsuario(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value, (int)comboBoxEmpleado.SelectedValue);

                nombreEmpleado = comboBoxEmpleado.Text; // Obtener el nombre del empleado seleccionado
            }
            else
            {
                datosReporte = CN_AuditoriaSesiones.ObtenerInstancia()
                    .ObtenerAuditoriaSesionesPorFecha(dateTimePickerFechaInicio.Value, dateTimePickerFechaFin.Value);
            }

            // Verificar si hay datos
            if (datosReporte == null || datosReporte.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el DataTable para almacenar los datos
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Auditoria", typeof(int));
            dt.Columns.Add("FechaHora", typeof(DateTime));
            dt.Columns.Add("TipoOperacion", typeof(string)); // Se cambia a string para mostrar "Login" o "Logout"
            dt.Columns.Add("ID_User", typeof(int));
            dt.Columns.Add("Username", typeof(string));

            // Llenar el DataTable con los datos transformando TipoOperacion
            foreach (var item in datosReporte)
            {
                string tipoOperacionTexto = item.TipoOperacion == 1 ? "Login" : "Logout"; // Transformación
                dt.Rows.Add(item.ID_Auditoria, item.FechaHora, tipoOperacionTexto, item.ID_User, item.Username);
            }

            // Crear el archivo Excel
            using (XLWorkbook wb = new XLWorkbook())
            {
                var hoja = wb.Worksheets.Add("Auditoría Sesiones");

                // Configurar información del reporte en las primeras filas
                hoja.Cell("A1").Value = "Reporte de Auditoría de Sesiones";
                hoja.Cell("A1").Style.Font.Bold = true;
                hoja.Cell("A1").Style.Font.FontSize = 14;

                hoja.Cell("A3").Value = "Empleado:";
                hoja.Cell("B3").Value = nombreEmpleado;
                hoja.Cell("A4").Value = "Fecha de Inicio:";
                hoja.Cell("B4").Value = dateTimePickerFechaInicio.Value.ToString("yyyy-MM-dd");
                hoja.Cell("A5").Value = "Fecha de Fin:";
                hoja.Cell("B5").Value = dateTimePickerFechaFin.Value.ToString("yyyy-MM-dd");

                // Agregar una línea vacía antes de la tabla
                int filaInicioDatos = 7;

                // Insertar los datos de la auditoría en la hoja de Excel
                var tabla = hoja.Cell(filaInicioDatos, 1).InsertTable(dt);
                hoja.Columns().AdjustToContents(); // Ajustar tamaño de columnas automáticamente

                // Guardar el archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Guardar Reporte",
                    FileName = $"Reporte_Auditoria_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Reporte exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
