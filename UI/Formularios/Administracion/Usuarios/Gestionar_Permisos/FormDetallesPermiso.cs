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
using UI.Administracion.Usuarios.Gestionar_Usuarios;

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

        private bool flagCambios = false;

        // Define una variable global para almacenar los datos originales
        private List<object> datosOriginalesAsociados = new List<object>();
        private List<object> datosOriginalesDisponibles = new List<object>();
        private int idPermiso;
        

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
            // Suscribirte al evento CellFormatting para ambos DataGridView
            dataGridViewDisponibles.CellFormatting += dataGridView_CellFormatting;
            dataGridViewAsociados.CellFormatting += dataGridView_CellFormatting;

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

                // Guardar los datos originales
                datosOriginalesAsociados = listaCombinada;
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
                // Guardar los datos originales
                datosOriginalesDisponibles = listaCombinada;
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
                if (flagCambios)
                {
                    DialogResult result = MessageBox.Show("Antes de continuar deberá guardar los cambios ahora o cancelar los cambios realizados ¿Desea guardar los cambios?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            guardarCambios();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar los cambios en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cambios descartados", "Cambios descartados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                PermisoTreeNode permisoNode = (PermisoTreeNode)e.Node;
                idPermiso = permisoNode.ID_Permission;
                labelPermiso.Text = permisoNode.Text;

                // Realizar la acción deseada con el ID del permiso
                CargarUsuariosYGruposAsociados(idPermiso);
                CargarUsuariosYGruposNoAsociados(idPermiso);
                flagCambios = false;
            }
        }

        private void FiltrarDataGridView(object sender, EventArgs e)
        {
            // Actualizar el estado de los filtros
            mostrarUsuarios = checkBoxUsuarios.Checked;
            mostrarGrupos = checkBoxGrupos.Checked;

            // Aplicar el filtro al DataGridView de usuarios y grupos asociados
            FiltrarDatosEnDataGridView(dataGridViewAsociados, datosOriginalesAsociados);
            // Aplicar el filtro al DataGridView de usuarios y grupos no asociados
            FiltrarDatosEnDataGridView(dataGridViewDisponibles, datosOriginalesDisponibles);
        }

        private void FiltrarDatosEnDataGridView(DataGridView dataGridView, List<object> datosOriginales)
        {
            var vista = dataGridView.DataSource as List<object>;
            if (vista != null)
            {
                if (!mostrarUsuarios && !mostrarGrupos)
                {
                    dataGridView.DataSource = new List<object>();
                    dataGridView.Refresh(); // Refrescar la vista después de cambiar los datos
                    return;
                }

                if (mostrarUsuarios && mostrarGrupos)
                {
                    dataGridView.DataSource = datosOriginales;
                    dataGridView.Refresh(); // Refrescar la vista después de cambiar los datos
                    return;
                }

                dataGridView.DataSource = datosOriginales
                    .Where(item => {
                        string tipo = (string)item.GetType().GetProperty("Tipo").GetValue(item);
                        bool filtroUsuarios = mostrarUsuarios && tipo == "Usuario";
                        bool filtroGrupos = mostrarGrupos && tipo == "Grupo";
                        return filtroUsuarios || filtroGrupos;
                    })
                    .ToList();

                dataGridView.Refresh(); // Refrescar la vista después de aplicar los filtros
            }
        }

        private void buttonQuitarPermiso_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en dataGridViewDisponibles
            if (dataGridViewAsociados.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                object selectedRow = dataGridViewAsociados.SelectedRows[0].DataBoundItem;

                // Obtener la lista de los disponibles y asociados
                List<object> disponibles = dataGridViewDisponibles.DataSource as List<object>;
                List<object> asociados = dataGridViewAsociados.DataSource as List<object>;

                // Agregar la fila seleccionada
                disponibles.Add(selectedRow);
                
                // Eliminar la fila seleccionada
                asociados.Remove(selectedRow);

                datosOriginalesAsociados = asociados;
                datosOriginalesDisponibles = disponibles;

                // Actualizar los DataGridViews
                dataGridViewDisponibles.DataSource = null;
                dataGridViewDisponibles.DataSource = disponibles;
                dataGridViewAsociados.DataSource = null;
                dataGridViewAsociados.DataSource = asociados;
                flagCambios = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila de los usuarios o grupos disponibles para quitar el permiso.");
            }
        }

        private void buttonDarPermiso_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en dataGridViewDisponibles
            if (dataGridViewDisponibles.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                object selectedRow = dataGridViewDisponibles.SelectedRows[0].DataBoundItem;

                // Obtener la lista de los disponibles y asociados
                List<object> disponibles = dataGridViewDisponibles.DataSource as List<object>;
                List<object> asociados = dataGridViewAsociados.DataSource as List<object>;

                // Agregar la fila seleccionada a los asociados
                asociados.Add(selectedRow);

                // Eliminar la fila seleccionada de los disponibles
                disponibles.Remove(selectedRow);

                datosOriginalesAsociados = asociados;
                datosOriginalesDisponibles = disponibles;

                // Actualizar los DataGridViews
                dataGridViewDisponibles.DataSource = null;
                dataGridViewDisponibles.DataSource = disponibles;
                dataGridViewAsociados.DataSource = null;
                dataGridViewAsociados.DataSource = asociados;
                flagCambios = true;
            }
            else
            {
                MessageBox.Show("Seleccione una fila de los usuarios o grupos disponibles para asignar el permiso.");
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = sender as DataGridView;

                // Obtener el valor de la columna "Tipo"
                string tipo = dataGridView.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

                // Verificar si la columna actual es "Tipo" y el valor es "Grupo"
                if (dataGridView.Columns[e.ColumnIndex].Name == "Tipo" && tipo == "Grupo")
                {
                    // Cambiar el color de fondo de la celda
                    e.CellStyle.BackColor = Color.CadetBlue;
                    // Puedes cambiar otros atributos de estilo aquí según tus necesidades
                }
            }
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Cierra y elimina el formulario de la memoria
            this.Dispose();
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            guardarCambios();
            this.Dispose();
            this.Close();
        }

        private void guardarCambios()
        {
            try
            {
                permisos.GuardarCambios(idPermiso, dataGridViewAsociados.DataSource as List<object>, dataGridViewDisponibles.DataSource as List<Object>);
                MessageBox.Show("Los cambios han sido guardados correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar los cambios en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
