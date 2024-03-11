using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Clases
{
    public class CN_Grupos
    {
        private List<Grupo> grupos;
        // Instancia estática privada para almacenar la única instancia de CN_Usuarios.
        private static CN_Grupos instancia;

        // Repositorio de usuarios
        private RepoGrupos repositorioGrupos;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Grupos()
        {
            repositorioGrupos = new RepoGrupos();
        }

        // Método estático para obtener la instancia única de CN_Usuarios.
        public static CN_Grupos ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Grupos();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {
                grupos = repositorioGrupos.ObtenerTodosLosGrupos();
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                return repositorioGrupos.ObtenerGrupoPorID(idGrupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Grupo> Filtrar(string filtroGroupname, string filtroID_Group, bool filtroIs_Enabled)
        {
            if (grupos != null && grupos.Any())
            {
                try
                {
                    // Realiza la búsqueda filtrada en la lista de usuarios
                    var resultado = grupos.Where(u =>
                    (string.IsNullOrEmpty(filtroGroupname) || u.Groupname.ToLower().Contains(filtroGroupname.ToLower())) &&
                    (string.IsNullOrEmpty(filtroID_Group) || u.ID_Group.ToString().Equals(filtroID_Group)) &&
                    (!filtroIs_Enabled || u.is_Enabled)
                    );
                    return resultado.ToList();                  
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que ocurra, por ejemplo, registro de error o notificación al usuario
                    Console.WriteLine("Ocurrió un error al filtrar grupos: " + ex.Message);
                    return Enumerable.Empty<Grupo>();
                }
            }
            else
            {
                grupos = repositorioGrupos.ObtenerTodosLosGrupos();
                return grupos;
            }
        }

        public List<Grupo> ObtenerGruposPorUsuario(int userID)
        {
            try
            {
                grupos = repositorioGrupos.ObtenerGruposPorUsuario(userID);
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Grupo> ObtenerGruposNoAsociadosAUsuario(int userID)
        {
            try
            {
                grupos = repositorioGrupos.ObtenerGruposNoAsociadosAUsuario(userID);
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Grupo> ObtenerGruposAsociadosAPermiso(int permisoID)
        {
            try
            {
                grupos = repositorioGrupos.ObtenerGruposAsociadosAPermiso(permisoID);
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Grupo> ObtenerGruposNoAsociadosAPermiso(int permisoID)
        {
            try
            {
                grupos = repositorioGrupos.ObtenerGruposNoAsociadosAPermiso(permisoID);
                return grupos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

    }
}
