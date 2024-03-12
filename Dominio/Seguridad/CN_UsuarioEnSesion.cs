using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.CD_Repositorios.ReposNegocio;
using Dominio.Clases;
using Modelo;

namespace Dominio
{
    public class CN_UsuarioEnSesion
    {
        
        private static CN_UsuarioEnSesion instancia;
        private Usuario usuario;
        private RepoUsuarios repoUsuarios;

        List<Permiso> listpermisosDeUsuarioEnSesion;
        List<Permiso> listpermisosDeGruposDelUsuarioEnSesion;
        private CN_Permisos permisos;
        private RepoPermisos repoPermisos;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_UsuarioEnSesion()
        {
            repoUsuarios = new RepoUsuarios();
            permisos = CN_Permisos.ObtenerInstancia();
        }

        // Método estático para obtener la instancia única de CN_UsuarioEnSesion.
        public static CN_UsuarioEnSesion ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_UsuarioEnSesion();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        // Método para obtener el usuario en sesión.
        public Usuario ObtenerUsuario()
        {
            return usuario;
        }

        public bool VerificarPermiso(int idPermiso)
        {
            // Verificar en la lista de permisos del usuario
            foreach (var permiso in listpermisosDeUsuarioEnSesion)
            {
                if (permiso.ID_Permission == idPermiso)
                {
                    return true;
                }
            }
            foreach (var permiso in listpermisosDeGruposDelUsuarioEnSesion)
            {
                if (permiso.ID_Permission == idPermiso)
                {
                    return true;
                }
            }
            // Si el permiso no se encontró en ninguna lista, retornar false
            return false;
        }

        public bool LoginUser(string username, string contraseña)
        {
            try
            {
                // Obtener el usuario por credenciales
                Usuario usuarioEncontrado = repoUsuarios.ObtenerUsuarioPorCredenciales(username, contraseña);

                // Si se encuentra un usuario con esas credenciales y está habilitado, retorna verdadero
                if (usuarioEncontrado != null && usuarioEncontrado.is_Enabled)
                {
                    usuario = usuarioEncontrado;
                    cargarPermisos();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que se produzca durante el proceso de autenticación
                throw ex;
            }
        }

        private void cargarPermisos()
        {
            listpermisosDeUsuarioEnSesion = permisos.ObtenerPermisosDeUsuario(usuario.ID_User);
            listpermisosDeGruposDelUsuarioEnSesion = permisos.ObtenerPermisosDeGruposPorID_User(usuario.ID_User);
        }
    }
}

