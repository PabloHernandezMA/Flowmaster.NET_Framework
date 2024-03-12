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
    public class CN_Ciudades
    {
        // Instancia estática privada para almacenar la única instancia de CN_Ciudades.
        private static CN_Ciudades instancia;
        private RepoCiudades repositorio;
        private List<Ciudad> ciudades;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Ciudades()
        {
            repositorio = new RepoCiudades();
            ciudades = new List<Ciudad>();
        }

        // Método estático para obtener la instancia única de CN_Ciudades.
        public static CN_Ciudades ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Ciudades();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Ciudad> ObtenerTodasLasCiudades()
        {
            try
            {
                // Si ya se han cargado las ciudades previamente, las devolvemos directamente.
                if (ciudades.Count > 0)
                {
                    return ciudades;
                }
                else
                {
                    // Si no se han cargado previamente, las cargamos desde el repositorio y las almacenamos en memoria.
                    ciudades = repositorio.ObtenerTodasLasCiudades();
                    return ciudades;
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
