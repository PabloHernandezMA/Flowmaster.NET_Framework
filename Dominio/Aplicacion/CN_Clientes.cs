using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Clientes
    {
        private static CN_Clientes instancia;
        private RepoClientes repositorio;
        private List<Cliente> clientes;

        private CN_Clientes()
        {
            repositorio = new RepoClientes();
            clientes = new List<Cliente>();
        }

        public static CN_Clientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Clientes();
            }
            return instancia;
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            try
            {
                if (clientes.Count > 0)
                {
                    return clientes;
                }
                else
                {
                    clientes = repositorio.ObtenerTodosLosClientes();
                    return clientes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> ObtenerClientePorIDCliente(int idCliente)
        {
            try
            {
                return repositorio.ObtenerClientePorIDCliente(idCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
