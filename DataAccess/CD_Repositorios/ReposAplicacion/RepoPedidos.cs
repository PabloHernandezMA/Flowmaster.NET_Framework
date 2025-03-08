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

        public List<Pedido> ObtenerTodosLosPedidosPorIDEmpleado(int idEmpleado)
        {
            List<Pedido> pedidos = new List<Pedido>();
            string consultaSQL = @"SELECT P.*
                            FROM PEDIDOS P
                            JOIN EMPLEADOS_PEDIDOS EP ON P.ID_Pedido = EP.ID_Pedido
                            WHERE EP.ID_Empleado = @ID_Empleado";

            // Debes inicializar la variable ID_Empleado antes de usarla en la consulta
            SqlParameter parametroIDEmpleado = new SqlParameter("@ID_Empleado", idEmpleado);
            parametros.Add(parametroIDEmpleado);

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

        public int ObtenerCantidadPedidosAsignadosPorIDEmpleado(int idEmpleado)
        {
            int cantidadPedidosPendientes = 0;
            string consultaSQL = @"SELECT COUNT(*)
                           FROM PEDIDOS P
                           JOIN EMPLEADOS_PEDIDOS EP ON P.ID_Pedido = EP.ID_Pedido
                           WHERE EP.ID_Empleado = @ID_Empleado
                           AND P.ID_Estado = 2"; // Filtra por pedidos en estado pendiente

            // Debes inicializar la variable ID_Empleado antes de usarla en la consulta
            SqlParameter parametroIDEmpleado = new SqlParameter("@ID_Empleado", idEmpleado);
            parametros.Add(parametroIDEmpleado);

            // Ejecuta la consulta y obtén el resultado como un escalar (un único valor)
            object resultado = ExecuteReader(consultaSQL);

            // Verifica si el resultado es nulo y si no, conviértelo a entero
            if (resultado != null && resultado != DBNull.Value)
            {
                cantidadPedidosPendientes = Convert.ToInt32(resultado);
            }

            return cantidadPedidosPendientes;
        }

        public int ContarPedidosPendientesAPartirDeFecha(DateTime fechaInicio)
        {
            int cantidadPedidosPendientes = 0;
            string consultaSQL = @"SELECT COUNT(*)
                           FROM PEDIDOS
                           WHERE ID_Estado = 1 -- Pedidos en estado pendiente
                           AND FechaInicio >= @FechaInicio"; // Filtra por la fecha especificada

            // Debes inicializar la variable FechaInicio antes de usarla en la consulta
            SqlParameter parametroFechaInicio = new SqlParameter("@FechaInicio", fechaInicio);
            parametros.Add(parametroFechaInicio);

            // Ejecuta la consulta y obtén el resultado como un escalar (un único valor)
            object resultado = ExecuteReader(consultaSQL);

            // Verifica si el resultado es nulo y si no, conviértelo a entero
            if (resultado != null && resultado != DBNull.Value)
            {
                cantidadPedidosPendientes = Convert.ToInt32(resultado);
            }

            return cantidadPedidosPendientes;
        }

        public List<Factura> ObtenerDatosParaFactura(int iDpedido)
        {
            List<Factura> facturas = new List<Factura>();
            string consultaSQL = @"
        SELECT 
            C.Nombre AS Nombre_Cliente,
            PR.Nombre AS Nombre_Producto,
            DP.Cantidad,
            DP.PrecioUnitario,
            DP.TotalDetalle
        FROM PEDIDOS P
        JOIN CLIENTES C ON P.ID_Cliente = C.ID_Cliente
        JOIN DETALLES_PEDIDO DP ON P.ID_Pedido = DP.ID_Pedido
        JOIN PRODUCTOS PR ON DP.ID_Producto = PR.ID_Producto
        WHERE P.ID_Pedido = @ID_Pedido";

            // Debes inicializar la variable ID_Empleado antes de usarla en la consulta
            parametros.Add(new SqlParameter("@ID_Pedido", iDpedido));

            DataTable tablaDatos = ExecuteReader(consultaSQL);
            
            foreach (DataRow fila in tablaDatos.Rows)
            {
                Factura factura = new Factura
                {
                    Nombre_Producto = fila["Nombre_Producto"].ToString(),
                    Cantidad = Convert.ToInt32(fila["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]),
                    TotalDetalle = Convert.ToDecimal(fila["TotalDetalle"])
                };
                facturas.Add(factura);
            }
            return facturas;
        }
    }
}
