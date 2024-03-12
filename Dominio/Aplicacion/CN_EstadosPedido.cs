using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_EstadosPedido
    {
        private static CN_EstadosPedido instancia;
        private RepoEstadosPedido repositorio;
        private List<EstadoPedido> estadosPedido;

        private CN_EstadosPedido()
        {
            repositorio = new RepoEstadosPedido();
            estadosPedido = new List<EstadoPedido>();
        }

        public static CN_EstadosPedido ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_EstadosPedido();
            }
            return instancia;
        }

        public List<EstadoPedido> ObtenerTodosLosEstadosPedido()
        {
            try
            {
                if (estadosPedido.Count > 0)
                {
                    return estadosPedido;
                }
                else
                {
                    estadosPedido = repositorio.ObtenerTodosLosEstadosPedido();
                    return estadosPedido;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EstadoPedido> ObtenerEstadosPedidosPorIDPedido(int idPedido)
        {
            try
            {
                return repositorio.ObtenerEstadosPedidosPorIDPedido(idPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
