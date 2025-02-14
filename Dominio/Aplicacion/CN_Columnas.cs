using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Columnas
    {
        private static CN_Columnas instancia;
        private RepoColumnas repositorio;
        private List<Columna> columnas;
        private CN_Columnas()
        {
            repositorio = new RepoColumnas();
            columnas = new List<Columna>();
        }

        public static CN_Columnas ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Columnas();
            }
            return instancia;
        }

        public List<Columna> ObtenerTodasLasColumnasDelProyecto(int idProyecto)
        {
            try
            {
                return repositorio.ObtenerTodasLasColumnasDelProyecto(idProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Columna> ObtenerTodasLasColumnasDelProyectoPorTarjeta(int idTarjeta)
        {
            try
            {
                return repositorio.ObtenerTodasLasColumnasDelProyectoPorTarjeta(idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AltaColumna(Columna columna)
        {
            try
            {
                return repositorio.AltaColumna(columna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarColumna(Columna columna)
        {
            try
            {
                return repositorio.ModificarColumna(columna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int BajaColumna(int idColumna)
        {
            try
            {
                return repositorio.BajaColumna(idColumna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
