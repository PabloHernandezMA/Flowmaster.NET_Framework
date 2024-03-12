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
    public class RepoDetallesPedido : RepositorioMaestro
    {
        public List<DetallePedido> ObtenerTodosLosDetallesPedido()
        {
            List<DetallePedido> detallesPedido = new List<DetallePedido>();
            string consultaSQL = "SELECT * FROM detalles_pedido"; // Ajusta esto según el nombre de tu tabla de detalles de pedido

            DataTable tablaDetallesPedido = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaDetallesPedido.Rows)
            {
                DetallePedido detallePedido = new DetallePedido
                {
                    ID_Pedido = Convert.ToInt32(fila["ID_Pedido"]),
                    ID_Producto = Convert.ToInt32(fila["ID_Producto"]),
                    Cantidad = Convert.ToSingle(fila["Cantidad"]),
                    TotalDetalle = Convert.ToDecimal(fila["TotalDetalle"]),
                    PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"])
                };
                detallesPedido.Add(detallePedido);
            }
            return detallesPedido;
        }
        public List<DetallePedido> ObtenerDetallesPedidoPorIDPedido(int idPedido)
        {
            List<DetallePedido> detallesPedido = new List<DetallePedido>();
            string consultaSQL = "SELECT * FROM Detalles_Pedido WHERE ID_Pedido = @ID_Pedido";
            parametros.Add(new SqlParameter("@ID_Pedido", idPedido));
            DataTable tablaDetallesPedido = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaDetallesPedido.Rows)
            {
                DetallePedido detallePedido = new DetallePedido
                {
                    ID_Pedido = Convert.ToInt32(fila["ID_Pedido"]),
                    ID_Producto = Convert.ToInt32(fila["ID_Producto"]),
                    Cantidad = Convert.ToSingle(fila["Cantidad"]),
                    TotalDetalle = Convert.ToDecimal(fila["TotalDetalle"]),
                    PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"])
                };
                detallesPedido.Add(detallePedido);
            }
            return detallesPedido;
        }
    }
}
