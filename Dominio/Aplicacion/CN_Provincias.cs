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
    public class CN_Provincias
    {
        // Instancia estática privada para almacenar la única instancia de CN_Provincias.
        private static CN_Provincias instancia;
        private RepoProvincias repositorio;
        private List<Provincia> provincias;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Provincias()
        {
            repositorio = new RepoProvincias();
            provincias = new List<Provincia>();
        }

        // Método estático para obtener la instancia única de CN_Provincias.
        public static CN_Provincias ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Provincias();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Provincia> ObtenerTodasLasProvincias()
        {
            try
            {
                // Si ya se han cargado las provincias previamente, las devolvemos directamente.
                if (provincias.Count > 0)
                {
                    return provincias;
                }
                else
                {
                    // Si no se han cargado previamente, las cargamos desde el repositorio y las almacenamos en memoria.
                    provincias = repositorio.ObtenerTodasLasProvincias();
                    return provincias;
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
