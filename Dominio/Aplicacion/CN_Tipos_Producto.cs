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
    public class CN_Tipos_Producto
    {
        // Instancia estática privada para almacenar la única instancia de CN_Tipos_Producto.
        private static CN_Tipos_Producto instancia;
        private RepoTipos_Producto repositorio;
        private List<Tipo_Producto> tipos_Producto;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Tipos_Producto()
        {
            repositorio = new RepoTipos_Producto();
            tipos_Producto = new List<Tipo_Producto>();
        }

        // Método estático para obtener la instancia única de CN_Tipos_Producto.
        public static CN_Tipos_Producto ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Tipos_Producto();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Tipo_Producto> ObtenerTodosLosTipos_Producto()
        {
            try
            {
                // Si ya se han cargado los tipos de producto previamente, los devolvemos directamente.
                if (tipos_Producto.Count > 0)
                {
                    return tipos_Producto;
                }
                else
                {
                    // Si no se han cargado previamente, los cargamos desde el repositorio y los almacenamos en memoria.
                    tipos_Producto = repositorio.ObtenerTodosLosTipos_Producto();
                    return tipos_Producto;
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
