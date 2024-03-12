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
    public class CN_Productos
    {
        private List<Producto> productos;

        // Instancia estática privada para almacenar la única instancia de CN_Productos.
        private static CN_Productos instancia;

        // Repositorio de productos
        private RepoProductos repositorioProductos;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Productos()
        {
            repositorioProductos = new RepoProductos();
        }

        // Método estático para obtener la instancia única de CN_Productos.
        public static CN_Productos ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Productos();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            try
            {
                productos = repositorioProductos.ObtenerTodosLosProductos();
                return productos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Producto> ObtenerProductosPorIDProducto(int idProducto)
        {
            try
            {
                productos = repositorioProductos.ObtenerProductosPorIDProducto(idProducto);
                return productos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public int AltaProducto(Producto producto)
        {
            try
            {
                return repositorioProductos.AltaProducto(producto);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public int BajaProducto(int idProducto)
        {
            try
            {
                return repositorioProductos.BajaProducto(idProducto);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public int ModificarProducto(Producto producto, int idProducto)
        {
            try
            {
                return repositorioProductos.ModificarProducto(producto, idProducto);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
