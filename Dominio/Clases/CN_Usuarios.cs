using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.CD_Repositorios;
using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;

namespace Dominio.Clases
{
    public class CN_Usuarios
    {
        private List<Usuario> usuarios;
        // Instancia estática privada para almacenar la única instancia de CN_Usuarios.
        private static CN_Usuarios instancia;

        // Repositorio de usuarios
        private RepoUsuarios repositorioUsuarios;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Usuarios()
        {
            repositorioUsuarios = new RepoUsuarios();
        }

        // Método estático para obtener la instancia única de CN_Usuarios.
        public static CN_Usuarios ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Usuarios();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            try
            {
                usuarios = repositorioUsuarios.ObtenerTodosLosUsuarios();
                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public Usuario ObtenerUsuarioPorID(int idUsuario)
        {
            try
            {
                return repositorioUsuarios.ObtenerUsuarioPorID(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> Filtrar(string filtroUsername, string filtroID_User, string filtroUser_Email, bool filtroIs_Enabled)
        {
            if (usuarios != null && usuarios.Any())
            {
                try
                {
                    // Realiza la búsqueda filtrada en la lista de usuarios
                    var resultado = usuarios.Where(u =>
                    (string.IsNullOrEmpty(filtroUsername) || u.Username.ToLower().Contains(filtroUsername.ToLower())) &&
                    (string.IsNullOrEmpty(filtroID_User) || u.ID_User.ToString().Equals(filtroID_User)) &&
                    (string.IsNullOrEmpty(filtroUser_Email) || u.User_Email.ToLower().Contains(filtroUser_Email.ToLower())) &&
                    (!filtroIs_Enabled || u.is_Enabled)
                    );
                    return resultado.ToList();
                    // Intenta realizar la búsqueda filtrada en la lista de usuarios
                    //return usuarios.FindAll(e => e.Username.ToLower().Contains(filtro.ToLower()));
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que ocurra, por ejemplo, registro de error o notificación al usuario
                    Console.WriteLine("Ocurrió un error al filtrar usuarios: " + ex.Message);
                    return Enumerable.Empty<Usuario>();
                }
            }
            else
            {
                usuarios = repositorioUsuarios.ObtenerTodosLosUsuarios();
                return usuarios;
            }
        }

        public List<Usuario> ObtenerUsuariosPorGrupo(int groupID)
        {
            try
            {
                usuarios = repositorioUsuarios.ObtenerUsuariosPorGrupo(groupID);
                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Usuario> ObtenerUsuariosNoAsociadosAGrupo(int groupID)
        {
            try
            {
                usuarios = repositorioUsuarios.ObtenerUsuariosNoAsociadosAGrupo(groupID);
                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Usuario> ObtenerUsuariosAsociadosAPermiso(int permisoID)
        {
            try
            {
                usuarios = repositorioUsuarios.ObtenerUsuariosAsociadosAPermiso(permisoID);
                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Usuario> ObtenerUsuariosNoAsociadosAPermiso(int permisoID)
        {
            try
            {
                usuarios = repositorioUsuarios.ObtenerUsuariosNoAsociadosAPermiso(permisoID);
                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
