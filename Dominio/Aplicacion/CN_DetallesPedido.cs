using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_DetallesPedido
    {
        private static CN_DetallesPedido instancia;
        private RepoDetallesPedido repositorio;
        private List<DetallePedido> detallesPedido;

        private CN_DetallesPedido()
        {
            repositorio = new RepoDetallesPedido();
            detallesPedido = new List<DetallePedido>();
        }

        public static CN_DetallesPedido ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_DetallesPedido();
            }
            return instancia;
        }

        public List<DetallePedido> ObtenerTodosLosDetallesPedido()
        {
            try
            {
                if (detallesPedido.Count > 0)
                {
                    return detallesPedido;
                }
                else
                {
                    detallesPedido = repositorio.ObtenerTodosLosDetallesPedido();
                    return detallesPedido;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetallePedido> ObtenerDetallesPedidoPorIDPedido(int idPedido)
        {
            try
            {
                return repositorio.ObtenerDetallesPedidoPorIDPedido(idPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
