using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoProyectos : RepositorioMaestro
    {
        public List<Proyecto> ObtenerTodosLosProyectos()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            string consultaSQL = "SELECT * FROM PROYECTOS";

            DataTable tablaProyectos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaProyectos.Rows)
            {
                Proyecto proyecto = new Proyecto
                {
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                    Nombre = fila["Nombre"].ToString(),
                    FechaInicio = Convert.ToDateTime(fila["FechaInicio"]),
                    FechaFin = Convert.ToDateTime(fila["FechaFin"]),
                    Estado = fila["Estado"].ToString()
                };
                proyectos.Add(proyecto);
            }
            return proyectos;
        }

        public int AltaProyecto(Proyecto proyecto)
        {
            string consultaSQL = @"INSERT INTO PROYECTOS (Nombre, FechaInicio, FechaFin, Estado)
                               VALUES (@Nombre, @FechaInicio, @FechaFin, @Estado)";
            parametros.Add(new SqlParameter("@Nombre", proyecto.Nombre));
            parametros.Add(new SqlParameter("@FechaInicio", proyecto.FechaInicio));
            parametros.Add(new SqlParameter("@FechaFin", proyecto.FechaFin));
            parametros.Add(new SqlParameter("@Estado", proyecto.Estado));

            return ExecuteNonQuery(consultaSQL);
        }

        public int BajaProyecto(int idProyecto)
        {
            string consultaSQL = "DELETE FROM PROYECTOS WHERE ID_Proyecto = @ID_Proyecto";
            parametros.Add(new SqlParameter("@ID_Proyecto", idProyecto));
            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarProyecto(Proyecto proyecto)
        {
            string consultaSQL = @"UPDATE PROYECTOS
                               SET Nombre = @Nombre,
                                   FechaInicio = @FechaInicio,
                                   FechaFin = @FechaFin,
                                   Estado = @Estado
                               WHERE ID_Proyecto = @ID_Proyecto";
            parametros.Add(new SqlParameter("@Nombre", proyecto.Nombre));
            parametros.Add(new SqlParameter("@FechaInicio", proyecto.FechaInicio));
            parametros.Add(new SqlParameter("@FechaFin", proyecto.FechaFin));
            parametros.Add(new SqlParameter("@Estado", proyecto.Estado));
            parametros.Add(new SqlParameter("@ID_Proyecto", proyecto.ID_Proyecto));

            return ExecuteNonQuery(consultaSQL);
        }

        public List<Proyecto> ObtenerTodosLosProyectosEnLosQueParticipaUnEmpleado(int idEmpleado)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            string consultaSQL = @"SELECT P.*
                               FROM PROYECTOS P
                               JOIN EMPLEADOxPROYECTO EP ON P.ID_Proyecto = EP.ID_Proyecto
                               WHERE EP.ID_Empleado = @ID_Empleado";
            parametros.Add(new SqlParameter("@ID_Empleado", idEmpleado));

            DataTable tablaProyectos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaProyectos.Rows)
            {
                Proyecto proyecto = new Proyecto
                {
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                    Nombre = fila["Nombre"].ToString(),
                    FechaInicio = Convert.ToDateTime(fila["FechaInicio"]),
                    FechaFin = (DateTime)(fila["FechaFin"] != DBNull.Value ? Convert.ToDateTime(fila["FechaFin"]) : (DateTime?)null),
                    Estado = fila["Estado"].ToString()
                };
                proyectos.Add(proyecto);
            }
            return proyectos;
        }

        // Devuelve todos los integrantes de un proyecto y sus cargos
        public List<Integrante> ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(int idProyecto)
        {
            List<Integrante> integrantes = new List<Integrante>();
            string consultaSQL = @"SELECT E.ID_Empleado, E.Nombre,
                                      EP.Cargo, EP.ID_Proyecto
                               FROM EMPLEADOS E
                               JOIN EMPLEADOxPROYECTO EP ON E.ID_Empleado = EP.ID_Empleado
                               WHERE EP.ID_Proyecto = @ID_Proyecto";
            parametros.Add(new SqlParameter("@ID_Proyecto", idProyecto));

            DataTable tablaIntegrantes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaIntegrantes.Rows)
            {
                Integrante integrante = new Integrante
                {
                    ID_Empleado = Convert.ToInt32(fila["ID_Empleado"]),
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                    Cargo = fila["Cargo"].ToString(),
                    Nombre = fila["Nombre"].ToString()
                };
                integrantes.Add(integrante);
            }
            return integrantes;
        }
        public int ModificarEmpleadosxProyecto(List<Integrante> integrantes)
        {
            // Obtenemos el ID del proyecto de la lista de integrantes
            if (integrantes == null || integrantes.Count == 0)
            {
                return 0; // Si la lista está vacía, no hay nada que modificar
            }

            int idProyecto = integrantes[0].ID_Proyecto;

            // Eliminar todos los registros para el proyecto
            string consultaSQLEliminar = @"DELETE FROM EMPLEADOxPROYECTO WHERE ID_Proyecto = @ID_Proyecto";
            parametros.Add(new SqlParameter("@ID_Proyecto", idProyecto));
            int filasEliminadas = ExecuteNonQuery(consultaSQLEliminar);

            // Insertar los nuevos registros de la lista
            foreach (var integrante in integrantes)
            {
                string consultaSQLInsertar = @"INSERT INTO EMPLEADOxPROYECTO (ID_Empleado, ID_Proyecto, Cargo)
                                      VALUES (@ID_Empleado, @ID_Proyecto, @Cargo)";
                parametros.Add(new SqlParameter("@ID_Empleado", integrante.ID_Empleado));
                parametros.Add(new SqlParameter("@ID_Proyecto", integrante.ID_Proyecto));
                parametros.Add(new SqlParameter("@Cargo", integrante.Cargo));

                // Ejecutamos la inserción para cada integrante
                ExecuteNonQuery(consultaSQLInsertar);
            }

            // Retornamos la cantidad de filas eliminadas (esto es solo una opción, podrías retornarlo de otra forma si prefieres)
            return filasEliminadas;
        }

    }

}
