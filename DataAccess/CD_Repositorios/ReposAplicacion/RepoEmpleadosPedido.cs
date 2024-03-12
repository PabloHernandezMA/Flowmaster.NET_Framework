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
    public class RepoEmpleadosPedido : RepositorioMaestro
    {
        public List<EmpleadoPedido> ObtenerTodosLosEmpleadosPedido()
        {
            List<EmpleadoPedido> empleadosPedido = new List<EmpleadoPedido>();
            string consultaSQL = "SELECT * FROM empleados_pedido"; // Ajusta esto según el nombre de tu tabla de empleados de pedido

            DataTable tablaEmpleadosPedido = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEmpleadosPedido.Rows)
            {
                EmpleadoPedido empleadoPedido = new EmpleadoPedido
                {
                    ID_Empleado = Convert.ToInt32(fila["ID_Empleado"]),
                    ID_Pedido = Convert.ToInt32(fila["ID_Pedido"])
                };
                empleadosPedido.Add(empleadoPedido);
            }
            return empleadosPedido;
        }
        public List<EmpleadoPedido> ObtenerEmpleadosPedidosPorIDPedido(int idPedido)
        {
            List<EmpleadoPedido> empleadosPedidos = new List<EmpleadoPedido>();
            string consultaSQL = "SELECT * FROM Empleados_Pedidos WHERE ID_Pedido = @ID_Pedido";
            parametros.Add(new SqlParameter("@ID_Pedido", idPedido));
            DataTable tablaEmpleadosPedidos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEmpleadosPedidos.Rows)
            {
                EmpleadoPedido empleadoPedido = new EmpleadoPedido
                {
                    ID_Empleado = Convert.ToInt32(fila["ID_Empleado"]),
                    ID_Pedido = Convert.ToInt32(fila["ID_Pedido"])
                };
                empleadosPedidos.Add(empleadoPedido);
            }
            return empleadosPedidos;
        }
    }
}
