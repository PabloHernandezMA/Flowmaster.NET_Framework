using DataAccess.CD_Repositorios.ReposSeguridad;
using Modelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Seguridad
{
    public class CN_AuditoriaSesiones
    {
        private List<AuditoriaSesiones> auditorias;

        // Instancia estática privada para almacenar la única instancia de CN_AuditoriaSesiones.
        private static CN_AuditoriaSesiones instancia;

        // Repositorio de auditoría de sesiones
        private RepoAuditoriaSesiones repositorioAuditoriaSesiones;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_AuditoriaSesiones()
        {
            repositorioAuditoriaSesiones = new RepoAuditoriaSesiones();
        }

        // Método estático para obtener la instancia única de CN_AuditoriaSesiones.
        public static CN_AuditoriaSesiones ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_AuditoriaSesiones();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<AuditoriaSesiones> ObtenerTodasLasAuditorias()
        {
            try
            {
                auditorias = repositorioAuditoriaSesiones.ObtenerTodasLasAuditorias();
                return auditorias;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<AuditoriaSesiones> ObtenerAuditoriaSesionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                auditorias = repositorioAuditoriaSesiones.ObtenerAuditoriaSesionesPorFecha(fechaInicio, fechaFin);
                return auditorias;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
        public List<AuditoriaSesiones> ObtenerAuditoriaSesionesPorFechaYUsuario(DateTime fechaInicio, DateTime fechaFin, int idUsuario)
        {
            try
            {
                auditorias = repositorioAuditoriaSesiones.ObtenerAuditoriaSesionesPorFechaYUsuario(fechaInicio, fechaFin, idUsuario);
                return auditorias;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public int RegistrarAuditoria(AuditoriaSesiones auditoria)
        {
            try
            {
                return repositorioAuditoriaSesiones.RegistrarAuditoria(auditoria);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
