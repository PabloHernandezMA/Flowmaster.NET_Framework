﻿using Modelo;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposNegocio
{
    public class RepoUsuarios : RepositorioMaestro
    {
        public List<Grupo> ObtenerTodosLosGruposMiembro;

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
        }

        public Usuario ObtenerUsuarioPorCredenciales(string username, string password)
        {
            try
            {
                parametros.Clear();
                string consultaSQL = "SELECT * FROM Usuarios WHERE Username = @Username AND User_Password = @Password";

                SqlParameter parametroUsername = new SqlParameter("@Username", SqlDbType.VarChar);
                parametroUsername.Value = username;
                parametros.Add(parametroUsername);

                SqlParameter parametroPassword = new SqlParameter("@Password", SqlDbType.VarChar);
                parametroPassword.Value = password;
                parametros.Add(parametroPassword);

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
        }


        public List<Usuario> ObtenerUsuariosPorGrupo(int grupoID)
        {
            List<Usuario> usuarios = new List<Usuario>();
            string consultaSQL = "SELECT USUARIOS.* FROM USUARIOS JOIN UxG ON USUARIOS.ID_User = UxG.ID_User WHERE UxG.ID_Group = @grupoID";

            parametros.Add(new SqlParameter("@grupoID", grupoID));

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

        public List<Usuario> ObtenerUsuariosNoAsociadosAGrupo(int grupoID)
        {
            List<Usuario> usuarios = new List<Usuario>();
            string consultaSQL = "SELECT USUARIOS.* FROM USUARIOS LEFT JOIN UxG ON USUARIOS.ID_User = UxG.ID_User AND UxG.ID_Group = @grupoID WHERE UxG.ID_User IS NULL";

            parametros.Add(new SqlParameter("@grupoID", grupoID));

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

        public List<Usuario> ObtenerUsuariosAsociadosAPermiso(int permisoID)
        {
            List<Usuario> usuarios = new List<Usuario>();
            string consultaSQL = "SELECT U.* FROM USUARIOS U JOIN PxU ON U.ID_User = PxU.ID_User WHERE PxU.ID_Permission = @permisoID";

            parametros.Add(new SqlParameter("@permisoID", permisoID));

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

        public List<Usuario> ObtenerUsuariosNoAsociadosAPermiso(int permisoID)
        {
            List<Usuario> usuarios = new List<Usuario>();
            string consultaSQL = "SELECT U.* FROM USUARIOS U LEFT JOIN PxU ON U.ID_User = PxU.ID_User AND PxU.ID_Permission = @permisoID WHERE PxU.ID_User IS NULL";

            parametros.Add(new SqlParameter("@permisoID", permisoID));

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
        public Usuario RestablecerContraseña(string username, string email, string password)
        {
            string querySQL = @"UPDATE USUARIOS
                                   SET User_Password = @Password
                                   WHERE Username = @Username OR User_Email = @Email";
            parametros.Add(new SqlParameter("@Password", password));
            parametros.Add(new SqlParameter("@Username", username));
            parametros.Add(new SqlParameter("@Email", email));

            ExecuteNonQuery(querySQL);
            string consultaSQL = @"SELECT * 
                            FROM USUARIOS 
                            WHERE Username = @Username OR User_Email = @Email";
            parametros.Add(new SqlParameter("@Username", username));
            parametros.Add(new SqlParameter("@Email", email));

            DataTable tablaUsuarios = ExecuteReader(consultaSQL);
            Usuario usuario = new Usuario();
            foreach (DataRow fila in tablaUsuarios.Rows)
            {
                usuario.ID_User = Convert.ToInt32(fila["ID_User"]);
                usuario.Username = fila["Username"].ToString();
                usuario.User_Password = fila["User_Password"].ToString();
                usuario.User_Email = fila["User_Email"].ToString();
                usuario.is_Enabled = Convert.ToBoolean(fila["is_Enabled"]);
            }
            return usuario;
        }
    }
}
