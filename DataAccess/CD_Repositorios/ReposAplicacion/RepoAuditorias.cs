using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoAuditorias : RepositorioMaestro
    {
        public List<AuditoriaTareaTarjeta> ObtenerAuditoriaTareas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<AuditoriaTareaTarjeta> auditoriaTareas = new List<AuditoriaTareaTarjeta>();
            string consultaSQL = "SELECT * FROM AuditoriaTareas WHERE FechaAccion >= @fechaInicio AND FechaAccion <= @fechaFin ORDER BY ID_Registro";
            parametros.Add(new SqlParameter("@fechaInicio", fechaInicio));
            parametros.Add(new SqlParameter("@fechaFin", fechaFin));

            DataTable tablaAuditoria = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAuditoria.Rows)
            {
                AuditoriaTareaTarjeta auditoriaTarea = new AuditoriaTareaTarjeta
                {
                    ID_Registro = Convert.ToInt32(fila["ID_Registro"]),
                    Accion = fila["Accion"].ToString(),
                    ID_Empleado = Convert.ToInt32(fila["ID_Empleado"]),
                    NombreEmpleado = fila["NombreEmpleado"].ToString(),
                    ID_Tarea = Convert.ToInt32(fila["ID_Tarea"]),
                    ID_Tarjeta = Convert.ToInt32(fila["ID_Tarjeta"]),
                    Descripcion = fila["Descripcion"].ToString(),
                    Completada = Convert.ToBoolean(fila["Completada"]),
                    FechaAccion = Convert.ToDateTime(fila["FechaAccion"]),
                    ID_Columna = Convert.ToInt32(fila["ID_Columna"]),
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"])
                };
                auditoriaTareas.Add(auditoriaTarea);
            }
            return auditoriaTareas;
        }
    }
}
