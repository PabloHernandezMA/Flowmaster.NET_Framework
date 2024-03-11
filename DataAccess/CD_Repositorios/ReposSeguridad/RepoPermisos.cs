using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DataAccess.CD_Repositorios.ReposNegocio
{
    public class RepoPermisos : RepositorioMaestro
    {
        public List<Permiso> ObtenerTodosLosPermisos()
        {
            List<Permiso> Permisos = new List<Permiso>();
            string consultaSQL = "SELECT * FROM Permisos";

            DataTable tablaPermisos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                Permiso Permiso = new Permiso
                {
                    ID_Permission = Convert.ToInt32(fila["ID_Permission"]),
                    PermissionName = fila["PermissionName"].ToString(),
                    ID_Form = Convert.ToInt32(fila["ID_Form"])
                };
                Permisos.Add(Permiso);
            }
            return Permisos;
        }

        public List<Permiso> ObtenerPermisosDeUsuario(int userID)
        {
            List<Permiso> permisos = new List<Permiso>();
            string consultaSQL = "SELECT DISTINCT P.* FROM PERMISOS P JOIN PxU ON P.ID_Permission = PxU.ID_Permission JOIN USUARIOS U ON PxU.ID_User = U.ID_User WHERE U.ID_User = @UserID";
            parametros.Add(new SqlParameter("@UserID", userID));
            DataTable tablaPermisos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                Permiso permiso = new Permiso
                {
                    ID_Permission = Convert.ToInt32(fila["ID_Permission"]),
                    PermissionName = fila["PermissionName"].ToString(),
                    ID_Form = Convert.ToInt32(fila["ID_Form"])
                };
                permisos.Add(permiso);
            }
            return permisos;
        }

        public List<Permiso> ObtenerPermisosDeGruposPorID_User(int userID)
        {
            List<Permiso> permisos = new List<Permiso>();
            string consultaSQL = "SELECT P.* FROM PERMISOS P JOIN PxG ON P.ID_Permission = PxG.ID_Permission JOIN GRUPOS G ON PxG.ID_Group = G.ID_Group JOIN UxG ON G.ID_Group = UxG.ID_Group JOIN USUARIOS U ON UxG.ID_User = U.ID_User WHERE U.ID_User = @UserID";
            parametros.Add(new SqlParameter("@UserID", userID));
            DataTable tablaPermisos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                Permiso permiso = new Permiso
                {
                    ID_Permission = Convert.ToInt32(fila["ID_Permission"]),
                    PermissionName = fila["PermissionName"].ToString(),
                    ID_Form = Convert.ToInt32(fila["ID_Form"])
                };
                permisos.Add(permiso);
            }
            return permisos;
        }
        public List<Permiso> ObtenerPermisosDeGrupoPorID_Group(int grupoID)
        {
            List<Permiso> permisos = new List<Permiso>();
            string consultaSQL = "SELECT PERMISOS.* FROM PERMISOS JOIN PxG ON PERMISOS.ID_Permission = PxG.ID_Permission WHERE PxG.ID_Group = @grupoID";
            parametros.Add(new SqlParameter("@grupoID", grupoID));
            DataTable tablaPermisos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                Permiso permiso = new Permiso
                {
                    ID_Permission = Convert.ToInt32(fila["ID_Permission"]),
                    PermissionName = fila["PermissionName"].ToString(),
                    ID_Form = Convert.ToInt32(fila["ID_Form"])
                };
                permisos.Add(permiso);
            }
            return permisos;
        }

        public int QuitarTodosLosUsuariosAsociadosAPermiso(int permisoId)
        {
            string consultaSQL = "DELETE FROM PxU WHERE ID_Permission = @permisoId";
            parametros.Add(new SqlParameter("@permisoId", permisoId));
            return ExecuteNonQuery(consultaSQL);
        }
        public int QuitarTodosLosGruposAsociadosAPermiso(int permisoId)
        {
            string consultaSQL = "DELETE FROM PxG WHERE ID_Permission = @permisoId";
            parametros.Add(new SqlParameter("@permisoId", permisoId));
            return ExecuteNonQuery(consultaSQL);
        }

        public int AgregarATablaPxU(int permisoId, int usuarioId)
        {
            string consultaSQL = "INSERT INTO PxU (ID_Permission, ID_User) VALUES (@permisoId, @usuarioId)";
            parametros.Add(new SqlParameter("@permisoId", permisoId));
            parametros.Add(new SqlParameter("@usuarioId", usuarioId));
            return ExecuteNonQuery(consultaSQL);
        }

        public int AgregarATablaPxG(int permisoId, int grupoId)
        {
            string consultaSQL = "INSERT INTO PxG (ID_Permission, ID_Group) VALUES (@permisoId, @grupoId)";
            parametros.Add(new SqlParameter("@permisoId", permisoId));
            parametros.Add(new SqlParameter("@grupoId", grupoId));
            return ExecuteNonQuery(consultaSQL);
        }
    }
}
