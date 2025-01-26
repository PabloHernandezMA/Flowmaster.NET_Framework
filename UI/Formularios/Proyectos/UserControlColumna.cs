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
    public partial class UserControlColumna : UserControl
    {
        public UserControlColumna()
        {
            InitializeComponent();
        }
        public string NombreColumna
        {
            get { return textBoxTituloColumna.Text; } // Para obtener el texto actual
            set { textBoxTituloColumna.Text = value; } // Para establecer el texto
        }
    }
}
