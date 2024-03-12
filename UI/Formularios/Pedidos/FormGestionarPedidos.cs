using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Pedidos
{
    public partial class FormGestionarPedidos : Form
    {
        private static FormGestionarPedidos instance;
        private CN_Pedidos pedidos;

        private FormGestionarPedidos()
        {
            InitializeComponent();
        }

        public static FormGestionarPedidos GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarPedidos();
            }
            return instance;
        }

        private void FormGestionarPedidos_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.DataSource = productos.ObtenerTodosLosProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
