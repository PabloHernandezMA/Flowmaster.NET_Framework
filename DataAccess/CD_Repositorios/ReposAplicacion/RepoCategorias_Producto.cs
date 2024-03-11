using Modelo;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoCategorias_Producto : RepositorioMaestro
    {
        public List<Categoria_Producto> ObtenerTodasLasCategorias_Producto()
        {
            List<Categoria_Producto> categorias_Producto = new List<Categoria_Producto>();
            string consultaSQL = "SELECT * FROM categorias_producto"; // Ajusta esto según el nombre de tu tabla de productos

            DataTable tablaCategorias_Producto = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaCategorias_Producto.Rows)
            {
                Categoria_Producto tipo_Producto = new Categoria_Producto
                {
                    ID_Categoria = Convert.ToInt32(fila["ID_Categoria"]),
                    Categoria = fila["Categoria"].ToString()
                };
                categorias_Producto.Add(tipo_Producto);
            }
            return categorias_Producto;
        }
    }
}
