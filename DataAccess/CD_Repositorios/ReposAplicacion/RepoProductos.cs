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
    public class RepoProductos : RepositorioMaestro
    {
        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> productos = new List<Producto>();
            string consultaSQL = "SELECT * FROM productos"; // Ajusta esto según el nombre de tu tabla de productos

            DataTable tablaproductos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaproductos.Rows)
            {
                Producto producto = new Producto
                {
                    ID_Producto = Convert.ToInt32(fila["ID_Producto"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_Categoria = Convert.ToInt32(fila["ID_Categoria"]),
                    ID_Tipo = Convert.ToInt32(fila["ID_Tipo"]),
                    PrecioVenta = Convert.ToDecimal(fila["PrecioVenta"]),
                    Existencias = Convert.ToInt32(fila["Existencias"]),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"]),
                    StockMinimo = Convert.ToInt32(fila["StockMinimo"]),
                    ID_Proveedor = Convert.ToInt32(fila["ID_Proveedor"])
                };
                productos.Add(producto);
            }
            return productos;
        }
    }
}
