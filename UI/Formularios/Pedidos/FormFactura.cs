using Dominio.Aplicacion;
using Microsoft.Reporting.WinForms;
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

namespace UI.Formularios.Pedidos
{
    public partial class FormFactura: Form
    {
        private static FormFactura instancia;
        private int idPedido;
        private string cliente;
        private FormFactura(int idPedido, string cliente)
        {
            InitializeComponent();
            this.idPedido = idPedido;
            this.cliente = cliente;
        }
        public static FormFactura ObtenerInstancia(int idPedido, string cliente)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormFactura(idPedido, cliente);
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            List<Factura> datosReporte = CN_Pedidos.ObtenerInstancia().ObtenerDatosParaFactura(idPedido);
            if (datosReporte == null || datosReporte.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bindingSource1.DataSource = datosReporte;
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportParameterCliente", cliente));
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetFactura", bindingSource1));
            this.reportViewer1.RefreshReport();
        }
    }
}
