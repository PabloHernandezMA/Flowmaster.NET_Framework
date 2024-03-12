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
        public List<Producto> ObtenerProductosPorIDProducto(int idProducto)
        {
            List<Producto> productos = new List<Producto>();
            string consultaSQL = "SELECT * FROM Productos WHERE ID_Producto = @ID_Producto";
            parametros.Add(new SqlParameter("@ID_Producto", idProducto));
            DataTable tablaProductos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaProductos.Rows)
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

        public int AltaProducto(Producto producto)
        {
        string consultaSQL = @"INSERT INTO Productos (Nombre, ID_Categoria, ID_Tipo, PrecioVenta, Existencias, Habilitado, StockMinimo, ID_Proveedor) 
                               VALUES (@Nombre, @ID_Categoria, @ID_Tipo, @PrecioVenta, @Existencias, @Habilitado, @StockMinimo, @ID_Proveedor)";
        parametros.Add(new SqlParameter("@Nombre", producto.Nombre));
        parametros.Add(new SqlParameter("@ID_Categoria", producto.ID_Categoria));
        parametros.Add(new SqlParameter("@ID_Tipo", producto.ID_Tipo));
        parametros.Add(new SqlParameter("@PrecioVenta", producto.PrecioVenta));
        parametros.Add(new SqlParameter("@Existencias", producto.Existencias));
        parametros.Add(new SqlParameter("@Habilitado", producto.Habilitado));
        parametros.Add(new SqlParameter("@StockMinimo", producto.StockMinimo));
        parametros.Add(new SqlParameter("@ID_Proveedor", producto.ID_Proveedor));
        
        return ExecuteNonQuery(consultaSQL);
        }

        public int BajaProducto(int idProducto)
        {
            string consultaSQL = "DELETE FROM Productos WHERE ID_Producto = @idProducto";
            parametros.Add(new SqlParameter("@idProducto", idProducto));
            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarProducto(Producto producto, int idProducto)
        {
            string consultaSQL = @"UPDATE Productos 
                                   SET Nombre = @Nombre, 
                                       ID_Categoria = @ID_Categoria, 
                                       ID_Tipo = @ID_Tipo, 
                                       PrecioVenta = @PrecioVenta, 
                                       Existencias = @Existencias, 
                                       Habilitado = @Habilitado, 
                                       StockMinimo = @StockMinimo, 
                                       ID_Proveedor = @ID_Proveedor 
                                   WHERE ID_Producto = @ID_Producto";
            parametros.Add(new SqlParameter("@Nombre", producto.Nombre));
            parametros.Add(new SqlParameter("@ID_Categoria", producto.ID_Categoria));
            parametros.Add(new SqlParameter("@ID_Tipo", producto.ID_Tipo));
            parametros.Add(new SqlParameter("@PrecioVenta", producto.PrecioVenta));
            parametros.Add(new SqlParameter("@Existencias", producto.Existencias));
            parametros.Add(new SqlParameter("@Habilitado", producto.Habilitado));
            parametros.Add(new SqlParameter("@StockMinimo", producto.StockMinimo));
            parametros.Add(new SqlParameter("@ID_Proveedor", producto.ID_Proveedor));
            parametros.Add(new SqlParameter("@ID_Producto", idProducto));
        
            return ExecuteNonQuery(consultaSQL);
        }
    }
}
