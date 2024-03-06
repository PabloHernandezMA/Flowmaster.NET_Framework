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

namespace UI.Formularios.Administracion.Usuarios.Gestionar_Permisos
{
    public partial class FormDetallesPermiso : Form
    {
        private CN_Grupos grupos;
        private CN_Usuarios usuario;
        private CN_Permisos permisos;
        private CN_Modulos modulos;
        private CN_Formularios formularios;

        // Declaración de variables globales para almacenar el estado de los filtros
        bool mostrarUsuarios = true;
        bool mostrarGrupos = true;
        bool mostrarSoloHabilitados = false;

        public FormDetallesPermiso()
        {
            InitializeComponent();
        }

        private void FormDetallesPermiso_Load(object sender, EventArgs e)
        {
            // Suscribir los eventos CheckedChanged de los CheckBox
            checkBoxUsuarios.CheckedChanged += FiltrarDataGridView;
            checkBoxGrupos.CheckedChanged += FiltrarDataGridView;
            checkBoxSoloHabilitados.CheckedChanged += FiltrarDataGridView;

            usuario = CN_Usuarios.ObtenerInstancia();
            grupos = CN_Grupos.ObtenerInstancia();
            permisos = CN_Permisos.ObtenerInstancia();
            modulos = CN_Modulos.ObtenerInstancia();
            formularios = CN_Formularios.ObtenerInstancia();

            CargarPermisos();
            
        }

        private void CargarUsuariosYGruposAsociados(int idPermiso)
        {
            try
            {
                // Obtener listas de usuarios y grupos
                List<Usuario> listaUsuarios = usuario.ObtenerUsuariosAsociadosAPermiso(idPermiso);
                List<Grupo> listaGrupos = grupos.ObtenerGruposAsociadosAPermiso(idPermiso);

                // Crear una lista combinada de usuarios y grupos
                List<object> listaCombinada = new List<object>();

                foreach (Usuario usuario in listaUsuarios)
                {
                    // Agregar usuarios a la lista combinada
                    listaCombinada.Add(new
                    {
                        ID = usuario.ID_User,
                        Nombre = usuario.Username,
                        Tipo = "Usuario",
                        Habilitado = usuario.is_Enabled ? "Sí" : "No"
                    });
                }

                foreach (Grupo grupo in listaGrupos)
                {
                    // Agregar grupos a la lista combinada
                    listaCombinada.Add(new
                    {
                        ID = grupo.ID_Group,
                        Nombre = grupo.Groupname,
                        Tipo = "Grupo",
                        Habilitado = grupo.is_Enabled ? "Sí" : "No"
                    });
                }

                // Enlazar la lista combinada al DataGridView
                dataGridViewAsociados.DataSource = listaCombinada;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarUsuariosYGruposNoAsociados(int idPermiso)
        {
            try
            {
                // Obtener listas de usuarios y grupos
                List<Usuario> listaUsuarios = usuario.ObtenerUsuariosNoAsociadosAPermiso(idPermiso);
                List<Grupo> listaGrupos = grupos.ObtenerGruposNoAsociadosAPermiso(idPermiso);

                // Crear una lista combinada de usuarios y grupos
                List<object> listaCombinada = new List<object>();

                foreach (Usuario usuario in listaUsuarios)
                {
                    // Agregar usuarios a la lista combinada
                    listaCombinada.Add(new
                    {
                        ID = usuario.ID_User,
                        Nombre = usuario.Username,
                        Tipo = "Usuario",
                        Habilitado = usuario.is_Enabled ? "Sí" : "No"
                    });
                }

                foreach (Grupo grupo in listaGrupos)
                {
                    // Agregar grupos a la lista combinada
                    listaCombinada.Add(new
                    {
                        ID = grupo.ID_Group,
                        Nombre = grupo.Groupname,
                        Tipo = "Grupo",
                        Habilitado = grupo.is_Enabled ? "Sí" : "No"
                    });
                }

                // Enlazar la lista combinada al DataGridView
                dataGridViewDisponibles.DataSource = listaCombinada;
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
                                        formularioNode.Nodes.Add(new PermisoTreeNode(permiso.PermissionName, permiso.ID_Permission));
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

        // Clase derivada de TreeNode para almacenar ID de Permiso
        public class PermisoTreeNode : TreeNode
        {
            public int ID_Permission { get; private set; }

            public PermisoTreeNode(string text, int idPermission) : base(text)
            {
                ID_Permission = idPermission;
            }
        }

        private void treeViewPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Verificar si el nodo seleccionado es un PermisoTreeNode
            if (e.Node is PermisoTreeNode)
            {
                PermisoTreeNode permisoNode = (PermisoTreeNode)e.Node;
                int idPermiso = permisoNode.ID_Permission;

                // Realizar la acción deseada con el ID del permiso
                CargarUsuariosYGruposAsociados(idPermiso);
                CargarUsuariosYGruposNoAsociados(idPermiso);
            }
        }

        private void FiltrarDataGridView(object sender, EventArgs e)
        {
            // Actualizar el estado de los filtros
            mostrarUsuarios = checkBoxUsuarios.Checked;
            mostrarGrupos = checkBoxGrupos.Checked;
            mostrarSoloHabilitados = checkBoxSoloHabilitados.Checked;

            // Aplicar los filtros a ambos DataGridView
            FiltrarDatosEnDataGridView(dataGridViewAsociados);
            FiltrarDatosEnDataGridView(dataGridViewDisponibles);
        }

        private void FiltrarDatosEnDataGridView(DataGridView dataGridView)
        {
            // Obtener la vista del DataGridView
            var vista = dataGridView.DataSource as DataView;
            if (vista != null)
            {
                // Aplicar filtros según el estado de los CheckBox
                vista.RowFilter = ConstruirFiltro();
            }
        }

        private string ConstruirFiltro()
        {
            List<string> filtros = new List<string>();

            // Construir filtro para usuarios si corresponde
            if (mostrarUsuarios)
            {
                if (mostrarSoloHabilitados)
                {
                    filtros.Add("([Tipo] = 'Usuario' AND [Habilitado] = 'Sí')");
                }
                else
                {
                    filtros.Add("([Tipo] = 'Usuario')");
                }
            }

            // Construir filtro para grupos si corresponde
            if (mostrarGrupos)
            {
                if (mostrarSoloHabilitados)
                {
                    filtros.Add("([Tipo] = 'Grupo' AND [Habilitado] = 'Sí')");
                }
                else
                {
                    filtros.Add("([Tipo] = 'Grupo')");
                }
            }

            // Unir todos los filtros con OR
            return string.Join(" OR ", filtros);
        }
    }
}
