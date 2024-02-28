using DataAccess;
using DataAccess.CD_Contratos;
using DataAccess.CD_Repositorios;
using Dominio.ValorObjeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class ModelUsuarios
    {
        private int ID_User;
        private string Username;
        private string User_Password;
        private string User_Email;
        private bool is_Enabled;

        private IUsuarios repositorioUsuarios;
        public EstadoEntidad Estado { private get; set; }
        
        public int ID_User1 { get => ID_User; set => ID_User = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string User_Password1 { get => User_Password; set => User_Password = value; }
        public string User_Email1 { get => User_Email; set => User_Email = value; }
        public bool is_Enabled1 { get => is_Enabled; set => is_Enabled = value; }
        
        public ModelUsuarios()
        {
            repositorioUsuarios = new RepoUsuarios();
        }
        
        public string SaveChanges()
        {
            string message=null;
            try
            {
                var usuarioDataModel = new EUsuarios();
                usuarioDataModel.ID_User = ID_User;
                usuarioDataModel.Username = Username;
                usuarioDataModel.User_Password = User_Password;
                usuarioDataModel.User_Email = User_Email;
                usuarioDataModel.is_Enabled = is_Enabled;

                switch (Estado)
                {
                    case EstadoEntidad.Agregado:
                        repositorioUsuarios.Agregar(usuarioDataModel);
                        message = "Agregago: " + usuarioDataModel.ToString();
                        break;
                    case EstadoEntidad.Eliminado:
                        repositorioUsuarios.Eliminar(ID_User);
                        message = "Eliminado usuario: " + ID_User;
                        break;
                    case EstadoEntidad.Modificado:
                        repositorioUsuarios.Editar(usuarioDataModel);
                        message = "Editado: " + usuarioDataModel.ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlException = ex as System.Data.SqlClient.SqlException;
                if (sqlException != null && sqlException.Number == 2627) 
                { message = "Error 2627: Registro duplicado"; }
                else { message = ex.ToString(); }
            }
            return message;
        }
        public List<ModelUsuarios> ObtenerTodos()
        {
            var usuarioDataModel = repositorioUsuarios.ObtenerTodos();
            var listUsuarios = new List<ModelUsuarios>();
            foreach (EUsuarios item in usuarioDataModel)
            {
                listUsuarios.Add(new ModelUsuarios
                {
                    ID_User = item.ID_User,
                    Username = item.Username,
                    User_Password = item.User_Password,
                    User_Email = item.User_Email,
                    is_Enabled = item.is_Enabled
                });
            }
            return listUsuarios;
        }
    }
}
