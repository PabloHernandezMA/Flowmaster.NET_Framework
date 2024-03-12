using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_EmpleadosPedido
    {
        private static CN_EmpleadosPedido instancia;
        private RepoEmpleadosPedido repositorio;
        private List<EmpleadoPedido> empleadosPedido;

        private CN_EmpleadosPedido()
        {
            repositorio = new RepoEmpleadosPedido();
            empleadosPedido = new List<EmpleadoPedido>();
        }

        public static CN_EmpleadosPedido ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_EmpleadosPedido();
            }
            return instancia;
        }

        public List<EmpleadoPedido> ObtenerTodosLosEmpleadosPedido()
        {
            try
            {
                if (empleadosPedido.Count > 0)
                {
                    return empleadosPedido;
                }
                else
                {
                    empleadosPedido = repositorio.ObtenerTodosLosEmpleadosPedido();
                    return empleadosPedido;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EmpleadoPedido> ObtenerEmpleadosPedidosPorIDPedido(int idPedido)
        {
            try
            {
                return repositorio.ObtenerEmpleadosPedidosPorIDPedido(idPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
