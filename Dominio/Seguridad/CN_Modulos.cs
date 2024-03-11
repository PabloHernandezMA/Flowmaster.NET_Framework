using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Clases
{
    public class CN_Modulos
    {
        private List<Modulo> modulos;
        // Instancia estática privada para almacenar la única instancia de CN_Usuarios.
        private static CN_Modulos instancia;

        // Repositorio de usuarios
        private RepoModulos repositorioModulos;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Modulos()
        {
            repositorioModulos = new RepoModulos();
        }

        // Método estático para obtener la instancia única de CN_Usuarios.
        public static CN_Modulos ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Modulos();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Modulo> ObtenerTodosLosModulos()
        {
            try
            {
                modulos = repositorioModulos.ObtenerTodosLosModulos();
                return modulos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
