using DataAccess.CD_Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CD_Repositorios
{
    public class RepoUsuarios : RepositorioMaestro, IUsuarios
    {
        private string obtenerTodos;
        private string agregar;
        private string editar;
        private string eliminar;

        public RepoUsuarios()
        {
            obtenerTodos = "SELECT ID_User, Username, User_Email, is_Enabled FROM Usuarios";
            agregar = "INSERT INTO Usuarios VALUES (@Username,@User_Password,@User_Email,@is_Enabled)";
            editar = "UPDATE Usuarios SET Username=@Username,User_Password=@User_Password,User_Email=@User_Email,is_Enabled=@is_Enabled WHERE ID_User=@ID_User";
            eliminar = "DELETE FROM Usuarios WHERE ID_User=@ID_User";
        }

        public IEnumerable<EUsuarios> ObtenerTodos()
        {
            var tablaResult = ExecuteReader(obtenerTodos);
            var listaUsuarios = new List<EUsuarios>();
            foreach (DataRow item in tablaResult.Rows)
            {
                listaUsuarios.Add(new EUsuarios
                {
                    ID_User = Convert.ToInt32(item[0]),
                    Username = item[1].ToString(),
                    User_Password = item[2].ToString(),
                    User_Email = item[3].ToString()//,
                    //is_Enabled = Convert.ToBoolean(item[4])
                });
            }
            return listaUsuarios;
        }

        public IEnumerable<EUsuarios> Buscar(Expression<Func<EUsuarios, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public int Agregar(EUsuarios entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Username", entidad.Username));
            parametros.Add(new SqlParameter("@User_Password", entidad.User_Password));
            parametros.Add(new SqlParameter("@User_Email", entidad.User_Email));
            parametros.Add(new SqlParameter("@is_Enabled", entidad.is_Enabled));
            return ExecuteNonQuery(agregar);
        }

        public int Editar(EUsuarios entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID_User", entidad.ID_User));
            parametros.Add(new SqlParameter("@Username", entidad.Username));
            parametros.Add(new SqlParameter("@User_Password", entidad.User_Password));
            parametros.Add(new SqlParameter("@User_Email", entidad.User_Email));
            parametros.Add(new SqlParameter("@is_Enabled", entidad.is_Enabled));
            return ExecuteNonQuery(editar);
        }

        public int Eliminar(int ID_User)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID_User", ID_User));
            return ExecuteNonQuery(eliminar);
        }

        public int GuardarCambios()
        {
            throw new NotImplementedException();
        }

        public EUsuarios ObtenerPorId(object id)
        {
            throw new NotImplementedException();
        }
    }
}
