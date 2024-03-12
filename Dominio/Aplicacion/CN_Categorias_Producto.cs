using DataAccess.CD_Repositorios.ReposAplicacion;
using DataAccess.CD_Repositorios.ReposNegocio;
using Dominio.Clases;
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
    public class CN_Categorias_Producto
    {
        // Instancia estática privada para almacenar la única instancia de CN_Usuarios.
        private static CN_Categorias_Producto instancia;
        private RepoCategorias_Producto repositorio;
        private List<Categoria_Producto> categorias_Producto;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Categorias_Producto()
        {
            repositorio = new RepoCategorias_Producto();
            categorias_Producto = new List<Categoria_Producto>();
        }

        // Método estático para obtener la instancia única de CN_Usuarios.
        public static CN_Categorias_Producto ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Categorias_Producto();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Categoria_Producto> ObtenerTodasLasCategorias_Producto()
        {
            try
            {
                // Si ya se han cargado las categorías previamente, las devolvemos directamente.
                if (categorias_Producto.Count > 0)
                {
                    return categorias_Producto;
                }
                else
                {
                    // Si no se han cargado previamente, las cargamos desde el repositorio y las almacenamos en memoria.
                    categorias_Producto = repositorio.ObtenerTodasLasCategorias_Producto();
                    return categorias_Producto;
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
