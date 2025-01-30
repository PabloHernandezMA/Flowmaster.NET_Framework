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
using UI.Formularios.Pedidos;

namespace UI.Formularios.Proyectos
{
    public partial class FormGestionarProyectos : Form
    {
        private CN_Proyectos proyectos;
        private static FormGestionarProyectos instance;
        private FormGestionarProyectos()
        {
            InitializeComponent();
        }
        public static FormGestionarProyectos GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FormGestionarProyectos();
            }
            return instance;
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Proyecto ObjSeleccionado = (Proyecto)dataGridView1.SelectedRows[0].DataBoundItem;
                using (FormProyecto formulario = FormProyecto.ObtenerInstancia(ObjSeleccionado))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proyecto.");
            }
        }

        private void FormGestionarProyectos_Load(object sender, EventArgs e)
        {
            proyectos = CN_Proyectos.ObtenerInstancia();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = proyectos.ObtenerTodosLosProyectos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
