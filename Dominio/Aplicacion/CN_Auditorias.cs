using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Auditorias
    {
        private static CN_Auditorias instancia;
        private RepoAuditorias repositorio;
        private CN_Auditorias()
        {
            repositorio = new RepoAuditorias();
        }
        public static CN_Auditorias ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Auditorias();
            }
            return instancia;
        }
        public List<AuditoriaTareaTarjeta> ObtenerAuditoriaTareas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return repositorio.ObtenerAuditoriaTareas(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
