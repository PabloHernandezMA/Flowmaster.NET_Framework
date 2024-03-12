using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoEstadosPedido : RepositorioMaestro
    {
        public List<EstadoPedido> ObtenerTodosLosEstadosPedido()
        {
            List<EstadoPedido> estadosPedido = new List<EstadoPedido>();
            string consultaSQL = "SELECT * FROM estados_pedido"; // Ajusta esto según el nombre de tu tabla de estados de pedido

            DataTable tablaEstadosPedido = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEstadosPedido.Rows)
            {
                EstadoPedido estadoPedido = new EstadoPedido
                {
                    ID_Estado = Convert.ToInt32(fila["ID_Estado"]),
                    Estado = fila["Estado"].ToString()
                };
                estadosPedido.Add(estadoPedido);
            }
            return estadosPedido;
        }
    }
}
