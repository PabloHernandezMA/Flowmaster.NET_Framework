using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Tarjetas
    {
        private static CN_Tarjetas instancia;
        private RepoTarjetas repositorio;
        private List<Tarjeta> tarjetas;
        private CN_Tarjetas()
        {
            repositorio = new RepoTarjetas();
            tarjetas = new List<Tarjeta>();
        }

        public static CN_Tarjetas ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Tarjetas();
            }
            return instancia;
        }

        public List<Tarjeta> ObtenerTodasLasTarjetasDeLaColumna(int idColumna)
        {
            try
            {
                return repositorio.ObtenerTodasLasTarjetasDeLaColumna(idColumna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AltaTarjeta(Tarjeta tarjeta)
        {
            try
            {
                return repositorio.AltaTarjeta(tarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarTarjeta(Tarjeta tarjeta)
        {
            try
            {
                return repositorio.ModificarTarjeta(tarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int BajaTarjeta(int idTarjeta)
        {
            try
            {
                return repositorio.BajaTarjeta(idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
