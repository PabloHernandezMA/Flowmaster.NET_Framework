using DataAccess.CD_Repositorios.ReposAplicacion;
using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Areas
    {
        // Instancia estática privada para almacenar la única instancia de CN_Areas.
        private static CN_Areas instancia;
        private RepoAreas repositorio;
        private List<Area> areas;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Areas()
        {
            repositorio = new RepoAreas();
            areas = new List<Area>();
        }

        // Método estático para obtener la instancia única de CN_Areas.
        public static CN_Areas ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Areas();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Area> ObtenerTodasLasAreas()
        {
            try
            {
                // Si ya se han cargado las áreas previamente, las devolvemos directamente.
                if (areas.Count > 0)
                {
                    return areas;
                }
                else
                {
                    // Si no se han cargado previamente, las cargamos desde el repositorio y las almacenamos en memoria.
                    areas = repositorio.ObtenerTodasLasAreas();
                    return areas;
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
