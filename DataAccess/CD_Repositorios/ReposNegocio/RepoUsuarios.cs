﻿using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposNegocio
{
    public class RepoUsuarios: RepositorioMaestro
    {
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string consultaSQL = "SELECT * FROM Usuarios"; // Ajusta esto según el nombre de tu tabla de usuarios

            DataTable tablaUsuarios = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaUsuarios.Rows)
            {
                Usuario usuario = new Usuario
                {
                    ID_User = Convert.ToInt32(fila["ID_User"]),
                    Username = fila["Username"].ToString(),
                    User_Password = fila["User_Password"].ToString(),
                    User_Email = fila["User_Email"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public IEnumerable<Usuario> Filtrar(string filter)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerUsuarioPorID(int idUsuario)
        {
            try
            {
                parametros.Clear();
                string consultaSQL = "SELECT * FROM Usuarios WHERE ID_User = @ID";

                SqlParameter parametroID = new SqlParameter("@ID", SqlDbType.Int);
                parametroID.Value = idUsuario;
                parametros.Add(parametroID);

                DataTable tablaUsuario = ExecuteReader(consultaSQL);

                if (tablaUsuario.Rows.Count > 0)
                {
                    DataRow fila = tablaUsuario.Rows[0];
                    Usuario usuario = new Usuario
                    {
                        ID_User = Convert.ToInt32(fila["ID_User"]),
                        Username = fila["Username"].ToString(),
                        User_Password = fila["User_Password"].ToString(),
                        User_Email = fila["User_Email"].ToString(),
                        is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                    };
                    return usuario;
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
            /*
            Usuario usuario = null;
            string consultaSQL = "SELECT * FROM Usuarios WHERE ID_User = @ID";

            SqlParameter parametroID = new SqlParameter("@ID", SqlDbType.Int);
            parametroID.Value = idUsuario;
            parametros.Add(parametroID);

            DataTable tablaUsuario = ExecuteReader(consultaSQL);

            if (tablaUsuario.Rows.Count > 0)
            {
                DataRow fila = tablaUsuario.Rows[0];
                usuario = new Usuario
                {
                    ID_User = Convert.ToInt32(fila["ID_User"]),
                    Username = fila["Username"].ToString(),
                    User_Password = fila["User_Password"].ToString(),
                    User_Email = fila["User_Email"].ToString(),
                    is_Enabled = Convert.ToBoolean(fila["is_Enabled"])
                };
            }
            return usuario;
            */
        }
    }
}