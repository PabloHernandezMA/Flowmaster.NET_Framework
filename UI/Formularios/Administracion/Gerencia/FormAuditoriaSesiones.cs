using Dominio.Seguridad;
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
    public partial class FormAuditoriaSesiones : Form
    {
        public FormAuditoriaSesiones()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CN_AuditoriaSesiones.ObtenerInstancia().ObtenerTodasLasAuditorias();
        }
    }
}
