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
    public class RepoPedidos : RepositorioMaestro
    {
        public List<Pedido> ObtenerTodosLosPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();
            string consultaSQL = "SELECT * FROM pedidos"; // Ajusta esto según el nombre de tu tabla de pedidos

            DataTable tablaPedidos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPedidos.Rows)
            {
                Pedido pedido = new Pedido
                {
                    ID_Pedido = Convert.ToInt32(fila["ID_Pedido"]),
                    ID_Cliente = Convert.ToInt32(fila["ID_Cliente"]),
                    ID_Sucursal = Convert.ToInt32(fila["ID_Sucursal"]),
                    TotalPedido = Convert.ToDecimal(fila["TotalPedido"]),
                    ID_Area = Convert.ToInt32(fila["ID_Area"]),
                    FechaInicio = Convert.ToDateTime(fila["FechaInicio"]),
                    FechaFin = Convert.ToDateTime(fila["FechaFin"]),
                    DescripcionSolicitud = fila["DescripcionSolicitud"].ToString(),
                    DescripcionTareasRealizadas = fila["DescripcionTareasRealizadas"].ToString(),
                    ID_Estado = Convert.ToInt32(fila["ID_Estado"])
                };
                pedidos.Add(pedido);
            }
            return pedidos;
        }

        public int AltaPedido(Pedido pedido)
        {
            string consultaSQL = @"INSERT INTO Pedidos (ID_Cliente, ID_Sucursal, TotalPedido, ID_Area, FechaInicio, FechaFin, DescripcionSolicitud, DescripcionTareasRealizadas, ID_Estado) 
                               VALUES (@ID_Cliente, @ID_Sucursal, @TotalPedido, @ID_Area, @FechaInicio, @FechaFin, @DescripcionSolicitud, @DescripcionTareasRealizadas, @ID_Estado)";
            parametros.Add(new SqlParameter("@ID_Cliente", pedido.ID_Cliente));
            parametros.Add(new SqlParameter("@ID_Sucursal", pedido.ID_Sucursal));
            parametros.Add(new SqlParameter("@TotalPedido", pedido.TotalPedido));
            parametros.Add(new SqlParameter("@ID_Area", pedido.ID_Area));
            parametros.Add(new SqlParameter("@FechaInicio", pedido.FechaInicio));
            parametros.Add(new SqlParameter("@FechaFin", pedido.FechaFin));
            parametros.Add(new SqlParameter("@DescripcionSolicitud", pedido.DescripcionSolicitud));
            parametros.Add(new SqlParameter("@DescripcionTareasRealizadas", pedido.DescripcionTareasRealizadas));
            parametros.Add(new SqlParameter("@ID_Estado", pedido.ID_Estado));

            return ExecuteNonQuery(consultaSQL);
        }

        public int BajaPedido(int idPedido)
        {
            string consultaSQL = "DELETE FROM Pedidos WHERE ID_Pedido = @ID_Pedido";
            parametros.Add(new SqlParameter("@ID_Pedido", idPedido));
            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarPedido(Pedido pedido, int idPedido)
        {
            string consultaSQL = @"UPDATE Pedidos 
                               SET ID_Cliente = @ID_Cliente, 
                                   ID_Sucursal = @ID_Sucursal, 
                                   TotalPedido = @TotalPedido, 
                                   ID_Area = @ID_Area, 
                                   FechaInicio = @FechaInicio, 
                                   FechaFin = @FechaFin, 
                                   DescripcionSolicitud = @DescripcionSolicitud, 
                                   DescripcionTareasRealizadas = @DescripcionTareasRealizadas, 
                                   ID_Estado = @ID_Estado 
                               WHERE ID_Pedido = @ID_Pedido";
            parametros.Add(new SqlParameter("@ID_Cliente", pedido.ID_Cliente));
            parametros.Add(new SqlParameter("@ID_Sucursal", pedido.ID_Sucursal));
            parametros.Add(new SqlParameter("@TotalPedido", pedido.TotalPedido));
            parametros.Add(new SqlParameter("@ID_Area", pedido.ID_Area));
            parametros.Add(new SqlParameter("@FechaInicio", pedido.FechaInicio));
            parametros.Add(new SqlParameter("@FechaFin", pedido.FechaFin));
            parametros.Add(new SqlParameter("@DescripcionSolicitud", pedido.DescripcionSolicitud));
            parametros.Add(new SqlParameter("@DescripcionTareasRealizadas", pedido.DescripcionTareasRealizadas));
            parametros.Add(new SqlParameter("@ID_Estado", pedido.ID_Estado));
            parametros.Add(new SqlParameter("@ID_Pedido", idPedido));

            return ExecuteNonQuery(consultaSQL);
        }
    }
}
