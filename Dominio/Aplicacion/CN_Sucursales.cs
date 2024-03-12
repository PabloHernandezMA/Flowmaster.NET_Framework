using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Sucursales
    {
        private static CN_Sucursales instancia;
        private RepoSucursales repositorio;
        private List<Sucursal> sucursales;

        private CN_Sucursales()
        {
            repositorio = new RepoSucursales();
            sucursales = new List<Sucursal>();
        }

        public static CN_Sucursales ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Sucursales();
            }
            return instancia;
        }

        public List<Sucursal> ObtenerTodasLasSucursales()
        {
            try
            {
                if (sucursales.Count > 0)
                {
                    return sucursales;
                }
                else
                {
                    sucursales = repositorio.ObtenerTodasLasSucursales();
                    return sucursales;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
