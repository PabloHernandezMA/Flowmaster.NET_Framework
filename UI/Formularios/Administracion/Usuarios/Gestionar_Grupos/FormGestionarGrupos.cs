using Dominio.Clases;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Formularios.Administracion.Usuarios.Gestionar_Grupos
{
    public partial class FormGestionarGrupos : Form
    {
        private CN_Grupos grupos;

        public FormGestionarGrupos()
        {
            InitializeComponent();
        }

        private void FormGestionarGrupos_Load(object sender, EventArgs e)
        {
            // Suscribir eventos para los controles
            textBoxNombre.TextChanged += FiltrarDatos;
            textBoxNumero.TextChanged += FiltrarDatos;
            checkBoxSoloHabilitados.CheckedChanged += FiltrarDatos;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            grupos = CN_Grupos.ObtenerInstancia();
        }

        private void FiltrarDatos(object sender, EventArgs e)
        {
            dataGridView1.DataSource = grupos.Filtrar(textBoxNombre.Text, textBoxNumero.Text, checkBoxSoloHabilitados.Checked);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Obtener la columna en la que se hizo clic
            DataGridViewColumn columna = dataGridView1.Columns[e.ColumnIndex];

            // Obtener los datos del DataGridView
            List<Grupo> grupos = dataGridView1.DataSource as List<Grupo>;

            // Verificar si la columna es válida y si hay datos
            if (columna != null && grupos != null && grupos.Any())
            {
                // Ordenar los datos según la columna en la que se hizo clic
                switch (columna.DataPropertyName)
                {
                    case "Groupname":
                        grupos = grupos.OrderBy(u => u.Groupname).ToList();
                        break;
                    case "ID_Group":
                        grupos = grupos.OrderBy(u => u.ID_Group).ToList();
                        break;
                    case "is_Enabled":
                        grupos = grupos.OrderBy(u => u.is_Enabled).ToList();
                        break;
                }
                // Actualizar el origen de datos del DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = grupos;
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxNumero.Text = "";
            checkBoxSoloHabilitados.Checked = false;
            listarGrupos();
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

        }

        private void listarGrupos()
        {
            try
            {
                dataGridView1.DataSource = grupos.ObtenerTodosLosGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
