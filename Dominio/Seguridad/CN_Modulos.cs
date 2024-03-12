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
        // Instancia estática privada para almacenar la única instancia de CN_Modulos.
        private static CN_Modulos instancia;
        private RepoModulos repositorio;
        private List<Modulo> modulos;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Modulos()
        {
            repositorio = new RepoModulos();
            modulos = new List<Modulo>();
        }

        // Método estático para obtener la instancia única de CN_Modulos.
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
                // Si ya se han cargado los módulos previamente, los devolvemos directamente.
                if (modulos.Count > 0)
                {
                    return modulos;
                }
                else
                {
                    // Si no se han cargado previamente, los cargamos desde el repositorio y los almacenamos en memoria.
                    modulos = repositorio.ObtenerTodosLosModulos();
                    return modulos;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
