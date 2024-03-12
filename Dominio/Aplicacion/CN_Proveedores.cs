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
    public class CN_Proveedores
    {
        // Instancia estática privada para almacenar la única instancia de CN_Proveedores.
        private static CN_Proveedores instancia;
        private RepoProveedores repositorio;
        private List<Proveedor> proveedores;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Proveedores()
        {
            repositorio = new RepoProveedores();
            proveedores = new List<Proveedor>();
        }

        // Método estático para obtener la instancia única de CN_Proveedores.
        public static CN_Proveedores ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Proveedores();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            try
            {
                // Si ya se han cargado los proveedores previamente, los devolvemos directamente.
                if (proveedores.Count > 0)
                {
                    return proveedores;
                }
                else
                {
                    // Si no se han cargado previamente, los cargamos desde el repositorio y los almacenamos en memoria.
                    proveedores = repositorio.ObtenerTodosLosProveedores();
                    return proveedores;
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
