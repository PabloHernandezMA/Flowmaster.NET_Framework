using Modelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Aplicacion;

namespace DataAccess.CD_Repositorios.ReposSeguridad
{
    public class RepoAuditoriaSesiones : RepositorioMaestro
    {
        public List<AuditoriaSesiones> ObtenerTodasLasAuditorias()
        {
            List<AuditoriaSesiones> auditorias = new List<AuditoriaSesiones>();
            string consultaSQL = "SELECT * FROM AuditoriaSesiones";

            DataTable tablaAuditorias = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAuditorias.Rows)
            {
                AuditoriaSesiones auditoria = new AuditoriaSesiones
                {
                    ID_Auditoria = Convert.ToInt32(fila["ID_Auditoria"]),
                    FechaHora = Convert.ToDateTime(fila["FechaHora"]),
                    TipoOperacion = Convert.ToInt32(fila["TipoOperacion"]),
                    ID_User = Convert.ToInt32(fila["ID_User"]),
                    Username = fila["Username"].ToString()
                };
                auditorias.Add(auditoria);
            }
            return auditorias;
        }
        public List<AuditoriaSesiones> ObtenerAuditoriaSesionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<AuditoriaSesiones> auditorias = new List<AuditoriaSesiones>();
            string consultaSQL = "SELECT * FROM AuditoriaSesiones WHERE FechaHora >= @fechaInicio AND FechaHora <= @fechaFin ORDER BY ID_Auditoria";
            parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));

            DataTable tablaAuditorias = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAuditorias.Rows)
            {
                AuditoriaSesiones auditoria = new AuditoriaSesiones
                {
                    ID_Auditoria = Convert.ToInt32(fila["ID_Auditoria"]),
                    FechaHora = Convert.ToDateTime(fila["FechaHora"]),
                    TipoOperacion = Convert.ToInt32(fila["TipoOperacion"]),
                    ID_User = Convert.ToInt32(fila["ID_User"]),
                    Username = fila["Username"].ToString()
                };
                auditorias.Add(auditoria);
            }
            return auditorias;
        }
        public List<AuditoriaSesiones> ObtenerAuditoriaSesionesPorFechaYUsuario(DateTime fechaInicio, DateTime fechaFin, int idUsuario)
        {
            List<AuditoriaSesiones> auditorias = new List<AuditoriaSesiones>();
            string consultaSQL = "SELECT * FROM AuditoriaSesiones WHERE FechaHora >= @fechaInicio AND FechaHora <= @fechaFin AND ID_User = @idUsuario ORDER BY ID_Auditoria";
            parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));

            DataTable tablaAuditorias = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAuditorias.Rows)
            {
                AuditoriaSesiones auditoria = new AuditoriaSesiones
                {
                    ID_Auditoria = Convert.ToInt32(fila["ID_Auditoria"]),
                    FechaHora = Convert.ToDateTime(fila["FechaHora"]),
                    TipoOperacion = Convert.ToInt32(fila["TipoOperacion"]),
                    ID_User = Convert.ToInt32(fila["ID_User"]),
                    Username = fila["Username"].ToString()
                };
                auditorias.Add(auditoria);
            }
            return auditorias;
        }
        public int RegistrarAuditoria(AuditoriaSesiones auditoria)
        {
            string consultaSQL = @"INSERT INTO AuditoriaSesiones (FechaHora, TipoOperacion, ID_User, Username) 
                               VALUES (@FechaHora, @TipoOperacion, @ID_User, @Username)";
            parametros.Add(new SqlParameter("@FechaHora", auditoria.FechaHora));
            parametros.Add(new SqlParameter("@TipoOperacion", auditoria.TipoOperacion));
            parametros.Add(new SqlParameter("@ID_User", auditoria.ID_User));
            parametros.Add(new SqlParameter("@Username", auditoria.Username));

            return ExecuteNonQuery(consultaSQL);
        }
    }
}
