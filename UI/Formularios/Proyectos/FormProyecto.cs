using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Proyectos
{
    public partial class FormProyecto : Form
    {
        private static FormProyecto instance;
        private FormProyecto()
        {
            InitializeComponent();
        }
        public static FormProyecto GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormProyecto();
            }
            return instance;
        }
    }
}
