using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Clases
{
    public class CN_Formularios
    {
        private List<Formulario> formularios;
        // Instancia estática privada para almacenar la única instancia de CN_Usuarios.
        private static CN_Formularios instancia;

        // Repositorio de usuarios
        private RepoFormularios repositorioFormularios;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Formularios()
        {
            repositorioFormularios = new RepoFormularios();
        }

        // Método estático para obtener la instancia única de CN_Usuarios.
        public static CN_Formularios ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Formularios();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Formulario> ObtenerTodosLosFormularios()
        {
            try
            {
                formularios = repositorioFormularios.ObtenerTodosLosFormularios();
                return formularios;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
