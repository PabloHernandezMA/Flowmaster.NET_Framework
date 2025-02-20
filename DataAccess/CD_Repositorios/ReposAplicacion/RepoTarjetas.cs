using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoTarjetas : RepositorioMaestro
    {
        public List<Tarjeta> ObtenerTodasLasTarjetasDeLaColumna(int idColumna)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            string consultaSQL = "SELECT * FROM TARJETAS WHERE ID_Columna = @ID_Columna ORDER BY Posicion";
            parametros.Add(new SqlParameter("@ID_Columna", idColumna));

            DataTable tablaTarjetas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTarjetas.Rows)
            {
                Tarjeta tarjeta = new Tarjeta
                {
                    ID_Tarjeta = Convert.ToInt32(fila["ID_Tarjeta"]),
                    Nombre = fila["Nombre"].ToString(),
                    Descripcion = fila["Descripcion"] != DBNull.Value ? fila["Descripcion"].ToString() : null,
                    Posicion = Convert.ToInt32(fila["Posicion"]),
                    Visible = Convert.ToBoolean(fila["Visible"]),
                    ID_Columna = Convert.ToInt32(fila["ID_Columna"])
                };
                tarjetas.Add(tarjeta);
            }
            return tarjetas;
        }

        public int AltaTarjeta(Tarjeta tarjeta)
        {
            string consultaSQL = @"INSERT INTO TARJETAS (Nombre, Descripcion, Posicion, Visible, ID_Columna)
                               VALUES (@Nombre, @Descripcion, @Posicion, @Visible, @ID_Columna)";
            parametros.Add(new SqlParameter("@Nombre", tarjeta.Nombre));
            parametros.Add(new SqlParameter("@Descripcion", tarjeta.Descripcion ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@Posicion", tarjeta.Posicion));
            parametros.Add(new SqlParameter("@Visible", tarjeta.Visible));
            parametros.Add(new SqlParameter("@ID_Columna", tarjeta.ID_Columna));

            return ExecuteNonQuery(consultaSQL);
        }

        public int BajaTarjeta(int idTarjeta)
        {
            string consultaSQL = "DELETE FROM TARJETAS WHERE ID_Tarjeta = @ID_Tarjeta";
            parametros.Add(new SqlParameter("@ID_Tarjeta", idTarjeta));
            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarTarjeta(Tarjeta tarjeta)
        {
            string consultaSQL = @"UPDATE TARJETAS
                               SET Nombre = @Nombre,
                                   Descripcion = @Descripcion,
                                   Posicion = @Posicion,
                                   Visible = @Visible,
                                   ID_Columna = @ID_Columna
                               WHERE ID_Tarjeta = @ID_Tarjeta";
            parametros.Add(new SqlParameter("@Nombre", tarjeta.Nombre));
            parametros.Add(new SqlParameter("@Descripcion", tarjeta.Descripcion ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@Posicion", tarjeta.Posicion));
            parametros.Add(new SqlParameter("@Visible", tarjeta.Visible));
            parametros.Add(new SqlParameter("@ID_Columna", tarjeta.ID_Columna));
            parametros.Add(new SqlParameter("@ID_Tarjeta", tarjeta.ID_Tarjeta));

            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarEmpleadoTarjetas(List<Empleado_Tarjeta> list, int idTarjeta)
        {
            // Obtenemos el ID del proyecto de la lista de integrantes
            if (list == null || list.Count == 0)
            {
                if (idTarjeta != 0)
                {
                    // Eliminar todos los registros para el proyecto
                    string consultaSQLEliminarTodo = @"DELETE FROM EMPLEADOxTARJETA WHERE ID_Tarjeta = @ID_Tarjeta";
                    parametros.Add(new SqlParameter("@ID_Tarjeta", idTarjeta));
                    return ExecuteNonQuery(consultaSQLEliminarTodo);
                }
                return 0; // Si la lista está vacía, no hay nada que modificar
            }

            idTarjeta = list[0].ID_Tarjeta;

            // Eliminar todos los registros para el proyecto
            string consultaSQLEliminar = @"DELETE FROM EMPLEADOxTARJETA WHERE ID_Tarjeta = @ID_Tarjeta";
            parametros.Add(new SqlParameter("@ID_Tarjeta", idTarjeta));
            int filasEliminadas = ExecuteNonQuery(consultaSQLEliminar);

            // Insertar los nuevos registros de la lista
            foreach (var integrante in list)
            {
                string consultaSQLInsertar = @"INSERT INTO EMPLEADOxTARJETA (ID_Empleado, ID_Tarjeta)
                                      VALUES (@ID_Empleado, @ID_Tarjeta)";
                parametros.Add(new SqlParameter("@ID_Empleado", integrante.ID_Empleado));
                parametros.Add(new SqlParameter("@ID_Tarjeta", integrante.ID_Tarjeta));

                // Ejecutamos la inserción para cada integrante
                ExecuteNonQuery(consultaSQLInsertar);
            }

            // Retornamos la cantidad de filas eliminadas (esto es solo una opción, podrías retornarlo de otra forma si prefieres)
            return filasEliminadas;
        }

        public List<TareaTarjeta> ObtenerTodasLasTareasDeLaTarjeta(int idTarjeta)
        {
            List<TareaTarjeta> tareas = new List<TareaTarjeta>();
            string consultaSQL = "SELECT * FROM TAREASxTARJETA WHERE ID_Tarjeta = @ID_Tarjeta ORDER BY ID_Tarea";
            parametros.Add(new SqlParameter("@ID_Tarjeta", idTarjeta));

            DataTable tablaTareas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTareas.Rows)
            {
                TareaTarjeta tarea = new TareaTarjeta
                {
                    ID_Tarea = Convert.ToInt32(fila["ID_Tarea"]),
                    Descripcion = fila["Descripcion"].ToString(),
                    Completada = Convert.ToBoolean(fila["Completada"]),
                    ID_Tarjeta = Convert.ToInt32(fila["ID_Tarjeta"]),
                };
                tareas.Add(tarea);
            }
            return tareas;
        }

        public int AltaTarea(TareaTarjeta tarea)
        {
            string consultaSQL = @"INSERT INTO TAREASxTARJETA (Descripcion, Completada, ID_Tarjeta)
                               VALUES (@Descripcion, @Completada, @ID_Tarjeta)";
            parametros.Add(new SqlParameter("@Descripcion", tarea.Descripcion));
            parametros.Add(new SqlParameter("@Completada", tarea.Completada));
            parametros.Add(new SqlParameter("@ID_Tarjeta", tarea.ID_Tarjeta));

            return ExecuteNonQuery(consultaSQL);
        }

        public int BajaTarea(int idTarea)
        {
            string consultaSQL = "DELETE FROM TAREASxTARJETA WHERE ID_Tarea = @ID_Tarea";
            parametros.Add(new SqlParameter("@ID_Tarea", idTarea));
            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarTarea(TareaTarjeta tarea)
        {
            string consultaSQL = @"UPDATE TAREASxTARJETA
                               SET Descripcion = @Descripcion,
                                   Completada = @Completada,
                                   ID_Tarjeta = @ID_Tarjeta
                               WHERE ID_Tarea = @ID_Tarea";
            parametros.Add(new SqlParameter("@Descripcion", tarea.Descripcion));
            parametros.Add(new SqlParameter("@Completada", tarea.Completada));
            parametros.Add(new SqlParameter("@ID_Tarjeta", tarea.ID_Tarjeta));
            parametros.Add(new SqlParameter("@ID_Tarea", tarea.ID_Tarea));

            return ExecuteNonQuery(consultaSQL);
        }

        
        public List<Empleado_Tarjeta> ObtenerTodosLosEmpleadosDeLaTarjeta(int idTarjeta)
        {
            List<Empleado_Tarjeta> empleados = new List<Empleado_Tarjeta>();
            string consultaSQL = @"select ET.*, E.Nombre
                                    from EMPLEADOxTARJETA ET
                                    INNER JOIN EMPLEADOS E ON
                                    ET.ID_Empleado = E.ID_Empleado
                                    WHERE ET.ID_Tarjeta = @ID_Tarjeta";
            parametros.Add(new SqlParameter("@ID_Tarjeta", idTarjeta));

            DataTable tablaEmpleados = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEmpleados.Rows)
            {
                Empleado_Tarjeta empleado = new Empleado_Tarjeta
                {
                    ID_Tarjeta = Convert.ToInt32(fila["ID_Tarjeta"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_Empleado = Convert.ToInt32(fila["ID_Empleado"])
                };
                empleados.Add(empleado);
            }
            return empleados;
        }
    }
}
