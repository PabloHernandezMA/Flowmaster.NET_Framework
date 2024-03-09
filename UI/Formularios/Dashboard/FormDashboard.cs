using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Dashboard
{
    public partial class FormDashboard : Form
    {
        private static FormDashboard instance;

        // Constructor privado para evitar la creación de instancias fuera de la clase
        private FormDashboard()
        {
            InitializeComponent();
        }

        // Método estático para obtener la instancia única del formulario
        public static FormDashboard GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormDashboard();
            }
            return instance;
        }
    }
}
