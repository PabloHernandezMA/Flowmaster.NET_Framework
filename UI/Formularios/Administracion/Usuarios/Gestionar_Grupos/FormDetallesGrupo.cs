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
    public partial class FormDetallesGrupo : Form
    {
        private CN_Grupos grupos;
        private CN_Usuarios usuarios;
        private CN_Permisos permisos;
        private CN_Modulos modulos;
        private CN_Formularios formularios;
        private bool isUpdatingNodeState = false;
        private int idGrupo;

        public FormDetallesGrupo(int idGrupo)
        {
            InitializeComponent();
            this.idGrupo = idGrupo;
        }

        private void FormDetallesGrupo_Load(object sender, EventArgs e)
        {
            usuarios = CN_Usuarios.ObtenerInstancia();
            permisos = CN_Permisos.ObtenerInstancia();
            modulos = CN_Modulos.ObtenerInstancia();
            formularios = CN_Formularios.ObtenerInstancia();
            grupos = CN_Grupos.ObtenerInstancia();
            CargarDatosGrupo();
            CargarUsuarios();
            CargarPermisos();
            MarcarPermisos(treeViewPermisos.Nodes, permisos.ObtenerPermisosDeGrupoPorID_Group(idGrupo));
        }

        private void MarcarPermisos(TreeNodeCollection nodes, List<Permiso> permisosGrupos)
        {
            foreach (TreeNode node in nodes)
            {
                // Verificar si el nombre del permiso del nodo está en la lista de permisos del usuario
                if (permisosGrupos.Any(permiso => permiso.PermissionName == node.Text))
                {
                    node.Checked = true; // Marcar el checkbox del nodo    
                }
                // Llamar recursivamente a la función para los nodos hijos
                MarcarPermisos(node.Nodes, permisosGrupos);
            }
        }

        private void CargarPermisos()
        {
            try
            {
                {
                    // Limpiar nodos previos
                    treeViewPermisos.Nodes.Clear();

                    // Obtener todos los módulos, formularios y permisos
                    List<Modulo> listmodulos = modulos.ObtenerTodosLosModulos();
                    List<Formulario> listformularios = formularios.ObtenerTodosLosFormularios();
                    List<Permiso> listpermisos = permisos.ObtenerTodosLosPermisos();

                    // Iterar sobre cada módulo
                    foreach (Modulo modulo in listmodulos)
                    {
                        // Crear nodo de módulo
                        TreeNode moduloNode = new TreeNode(modulo.ModuleName);

                        // Iterar sobre cada formulario
                        foreach (Formulario formulario in listformularios)
                        {
                            // Verificar si el formulario pertenece al módulo actual
                            if (formulario.ID_Module == modulo.ID_Module)
                            {
                                // Crear nodo de formulario
                                TreeNode formularioNode = new TreeNode(formulario.FormName);

                                // Iterar sobre cada permiso
                                foreach (Permiso permiso in listpermisos)
                                {
                                    // Verificar si el permiso pertenece al formulario actual
                                    if (permiso.ID_Form == formulario.ID_Form)
                                    {
                                        // Agregar nodo de permiso al nodo de formulario
                                        formularioNode.Nodes.Add(new TreeNode(permiso.PermissionName));
                                    }
                                }

                                // Agregar nodo de formulario al nodo de módulo
                                moduloNode.Nodes.Add(formularioNode);
                            }
                        }

                        // Agregar nodo de módulo al TreeView
                        treeViewPermisos.Nodes.Add(moduloNode);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                dataGridViewUsuariosDisponibles.DataSource = usuarios.ObtenerUsuariosNoAsociadosAGrupo(idGrupo);
                dataGridViewUsuariosMiembro.DataSource = usuarios.ObtenerUsuariosPorGrupo(idGrupo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarDatosGrupo()
        {
            try
            {
                Grupo grupoData = grupos.ObtenerGrupoPorID(idGrupo);
                if (grupos != null)
                {
                    textBoxNombre.Text = grupoData.Groupname;
                    checkBoxHabilitado.Checked = grupoData.is_Enabled;
                    labelNumeroID.Text = grupoData.ID_Group.ToString();
                }
                else
                {
                    MessageBox.Show("El grupo no fue encontrado.");
                    this.Close(); // Cierra el formulario si no se encuentra el usuario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message);
                // this.Close(); // Cierra el formulario en caso de error
            }
        }
    }
}