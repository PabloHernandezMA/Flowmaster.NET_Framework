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
    public partial class FormGestionarPedidos : Form
    {
        private static FormGestionarPedidos instance;

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
    }
}
