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
    }
}
