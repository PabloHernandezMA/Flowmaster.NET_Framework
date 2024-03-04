using Dominio;
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

namespace UI.Administracion.Usuarios.Gestionar_Usuarios
{
    public partial class FormDetallesUsuario : Form
    {
        private CN_Grupos grupos;
        private CN_Usuarios usuario;
        private CN_Permisos permisos;
        private CN_Modulos modulos;
        private CN_Formularios formularios;

        private int idUsuario;

        public FormDetallesUsuario(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void FormDetallesUsuario_Load(object sender, EventArgs e)
        {
            usuario = CN_Usuarios.ObtenerInstancia();
            permisos = CN_Permisos.ObtenerInstancia();
            modulos = CN_Modulos.ObtenerInstancia();
            formularios = CN_Formularios.ObtenerInstancia();
            CargarDatosUsuario();
            CargarGrupos();
            CargarPermisos();
            MarcarPermisos(treeViewPermisos.Nodes, permisos.ObtenerPermisosDeUsuario(idUsuario), permisos.ObtenerPermisosDeGruposPorID_User(idUsuario));
            treeViewPermisos.AfterCheck += treeViewPermisos_VerificarDespues;
        }

        private void CargarDatosUsuario()
        {
            try
            {
                Usuario usuarioData = usuario.ObtenerUsuarioPorID(idUsuario);
                if (usuario != null)
                {
                    textBoxNombre.Text = usuarioData.Username;
                    textBoxContrasena.Text = usuarioData.User_Password;
                    textBoxEmail.Text = usuarioData.User_Email;
                    checkBoxHabilitado.Checked = usuarioData.is_Enabled;
                    labelNumeroID.Text = usuarioData.ID_User.ToString();
                }
                else
                {
                    MessageBox.Show("El usuario no fue encontrado.");
                    this.Close(); // Cierra el formulario si no se encuentra el usuario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message);
               // this.Close(); // Cierra el formulario en caso de error
            }
        }

        private void CargarGrupos()
        {
            grupos = CN_Grupos.ObtenerInstancia();
            try
            {
                dataGridViewGruposDisponibles.DataSource = grupos.ObtenerGruposNoAsociadosAUsuario(idUsuario);
                dataGridViewGruposMiembro.DataSource = grupos.ObtenerGruposPorUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void MarcarPermisos(TreeNodeCollection nodes, List<Permiso> permisosUsuario, List<Permiso> permisosGrupos)
        {
            foreach (TreeNode node in nodes)
            {
                // Verificar si el nombre del permiso del nodo está en la lista de permisos del usuario
                if (permisosUsuario.Any(permiso => permiso.PermissionName == node.Text))
                {
                    node.Checked = true; // Marcar el checkbox del nodo
                }
                // Verificar si el nombre del permiso del nodo está en la lista de permisos heredados de grupos
                else if (permisosGrupos.Any(permiso => permiso.PermissionName == node.Text))
                {
                    node.Checked = true; // Marcar el checkbox del nodo
                    node.ForeColor = System.Drawing.Color.Gold; // Cambiar el color de fondo para indicar que está deshabilitado                                                                     
                }

                // Llamar recursivamente a la función para los nodos hijos
                MarcarPermisos(node.Nodes, permisosUsuario, permisosGrupos);
            }
        }

        private void treeViewPermisos_VerificarAntes(object sender, TreeViewCancelEventArgs e)
        {
            // Verificar si el nodo es un permiso heredado del grupo (color de primer plano igual a Gold)
            if (e.Node.ForeColor == System.Drawing.Color.Gold)
            {
                // Mostrar un mensaje al usuario
                MessageBox.Show("No puede cambiar el estado de este permiso ya que es heredado de un grupo al que pertenece.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Restaurar el estado de Checked del nodo a true
                e.Cancel = true;
            }
        }

        private void treeViewPermisos_VerificarDespues(object sender, TreeViewEventArgs e)
        {
            // Verificar si el nodo está marcado
            if (e.Node.Checked)
            {
                // Buscar el nombre del permiso en la lista permisosGrupos
                if (permisos.ObtenerPermisosDeGruposPorID_User(idUsuario).Any(permiso => permiso.PermissionName == e.Node.Text))
                {
                    // Mostrar un mensaje de advertencia al usuario
                    MessageBox.Show("Aunque desactive este permiso, el usuario aún tendrá acceso debido a que es un permiso heredado de un grupo al que pertenece.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
