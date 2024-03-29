﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CD_Repositorios.ReposNegocio
{
    public class RepoGrupos : RepositorioMaestro
    {
        public List<Grupo> ObtenerTodosLosGrupos()
        {
            List<Grupo> grupos = new List<Grupo>();
            string consultaSQL = "SELECT * FROM Grupos";

            DataTable tablaGrupos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaGrupos.Rows)
            {
                Grupo grupo = new Grupo
                {
                    ID_Group = Convert.ToInt32(fila["ID_Group"]),
                    Groupname = fila["Groupname"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
                grupos.Add(grupo);
            }
            return grupos;
        }

        public List<Grupo> ObtenerGruposPorUsuario(int userID)
        {
            List<Grupo> grupos = new List<Grupo>();
            string consultaSQL = "SELECT g.* FROM Grupos g INNER JOIN UxG u ON g.ID_Group = u.ID_Group WHERE u.ID_User = @UserID";

            parametros.Add(new SqlParameter("@UserID", userID));

            DataTable tablaGrupos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaGrupos.Rows)
            {
                Grupo grupo = new Grupo
                {
                    ID_Group = Convert.ToInt32(fila["ID_Group"]),
                    Groupname = fila["Groupname"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
                grupos.Add(grupo);
            }

            return grupos;
        }

        public List<Grupo> ObtenerGruposNoAsociadosAUsuario(int userID)
        {
            List<Grupo> grupos = new List<Grupo>();
            string consultaSQL = "SELECT g.* FROM Grupos g WHERE g.ID_Group NOT IN (SELECT ID_Group FROM UxG WHERE ID_User = @UserID)";

            parametros.Add(new SqlParameter("@UserID", userID));

            DataTable tablaGrupos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaGrupos.Rows)
            {
                Grupo grupo = new Grupo
                {
                    ID_Group = Convert.ToInt32(fila["ID_Group"]),
                    Groupname = fila["Groupname"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
                grupos.Add(grupo);
            }

            return grupos;
        }

        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                List<Grupo> grupos = new List<Grupo>();
                parametros.Clear();
                string consultaSQL = "SELECT * FROM Grupos WHERE ID_Group = @ID";

                parametros.Add(new SqlParameter("@ID", idGrupo));

                DataTable tablaGrupo = ExecuteReader(consultaSQL);
                if (tablaGrupo.Rows.Count > 0)
                {
                    DataRow fila = tablaGrupo.Rows[0];
                    Grupo grupo = new Grupo
                    {
                        ID_Group = Convert.ToInt32(fila["ID_Group"]),
                        Groupname = fila["Groupname"].ToString(),
                        is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                    };
                    return grupo;
                }
                else
                {
                    return null; // Retorna null si no se encuentra el usuario
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupo> ObtenerGruposAsociadosAPermiso(int permisoID)
        {
            List<Grupo> grupos = new List<Grupo>();
            string consultaSQL = "SELECT G.* FROM GRUPOS G JOIN PxG ON G.ID_Group = PxG.ID_Group WHERE PxG.ID_Permission = @permisoID";

            parametros.Add(new SqlParameter("@permisoID", permisoID));

            DataTable tablaGrupos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaGrupos.Rows)
            {
                Grupo grupo = new Grupo
                {
                    ID_Group = Convert.ToInt32(fila["ID_Group"]),
                    Groupname = fila["Groupname"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
                grupos.Add(grupo);
            }

            return grupos;
        }

        public List<Grupo> ObtenerGruposNoAsociadosAPermiso(int permisoID)
        {
            List<Grupo> grupos = new List<Grupo>();
            string consultaSQL = "SELECT G.* FROM GRUPOS G LEFT JOIN PxG ON G.ID_Group = PxG.ID_Group AND PxG.ID_Permission = @permisoID WHERE PxG.ID_Group IS NULL";

            parametros.Add(new SqlParameter("@permisoID", permisoID));

            DataTable tablaGrupos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaGrupos.Rows)
            {
                Grupo grupo = new Grupo
                {
                    ID_Group = Convert.ToInt32(fila["ID_Group"]),
                    Groupname = fila["Groupname"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
                grupos.Add(grupo);
            }

            return grupos;
        }
    }
}
