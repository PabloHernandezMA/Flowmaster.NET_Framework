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
                    Estado = Convert.ToBoolean(fila["Estado"])
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

        public List<Proyecto> ObtenerTodosLosProyectosEnLosQueParticipaUnUsuario(int idUsuario)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            string consultaSQL = @"SELECT P.*
                               FROM PROYECTOS P
                               JOIN USUARIOxPROYECTO UP ON P.ID_Proyecto = UP.ID_Proyecto
                               WHERE UP.ID_User = @ID_User";
            parametros.Add(new SqlParameter("@ID_User", idUsuario));

            DataTable tablaProyectos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaProyectos.Rows)
            {
                Proyecto proyecto = new Proyecto
                {
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                    Nombre = fila["Nombre"].ToString(),
                    FechaInicio = Convert.ToDateTime(fila["FechaInicio"]),
                    FechaFin = (DateTime)(fila["FechaFin"] != DBNull.Value ? Convert.ToDateTime(fila["FechaFin"]) : (DateTime?)null),
                    Estado = Convert.ToBoolean(fila["Estado"])
                };
                proyectos.Add(proyecto);
            }
            return proyectos;
        }

        // Métodos para Tarjetas
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
                                   Visible = @Visible
                               WHERE ID_Tarjeta = @ID_Tarjeta";
            parametros.Add(new SqlParameter("@Nombre", tarjeta.Nombre));
            parametros.Add(new SqlParameter("@Descripcion", tarjeta.Descripcion ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@Posicion", tarjeta.Posicion));
            parametros.Add(new SqlParameter("@Visible", tarjeta.Visible));
            parametros.Add(new SqlParameter("@ID_Tarjeta", tarjeta.ID_Tarjeta));

            return ExecuteNonQuery(consultaSQL);
        }

        // Devuelve todos los integrantes de un proyecto y sus cargos
        public List<Integrante> ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(int idProyecto)
        {
            List<Integrante> integrantes = new List<Integrante>();
            string consultaSQL = @"SELECT U.ID_Usuario, U.Nombre AS NombreUsuario, U.Apellido, 
                                      UP.Cargo
                               FROM USUARIOS U
                               JOIN USUARIOxPROYECTO UP ON U.ID_Usuario = UP.ID_Usuario
                               WHERE UP.ID_Proyecto = @ID_Proyecto";
            parametros.Add(new SqlParameter("@ID_Proyecto", idProyecto));

            DataTable tablaIntegrantes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaIntegrantes.Rows)
            {
                Integrante integrante = new Integrante
                {
                    ID_Usuario = Convert.ToInt32(fila["ID_Usuario"]),
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                    Cargo = fila["Cargo"].ToString()
                };
                integrantes.Add(integrante);
            }
            return integrantes;
        }

        // Devuelve todos los proyectos en los que participa un usuario junto con su cargo
        public List<ProyectoIntegracion> ObtenerTodosLosProyectosDeUnUsuarioYSuCargo(int idUsuario)
        {
            List<ProyectoIntegracion> proyectos = new List<ProyectoIntegracion>();
            string consultaSQL = @"SELECT P.ID_Proyecto, P.Nombre AS NombreProyecto, P.FechaInicio, 
                                      P.FechaFin, P.Estado, UP.Cargo
                               FROM PROYECTOS P
                               JOIN USUARIOxPROYECTO UP ON P.ID_Proyecto = UP.ID_Proyecto
                               WHERE UP.ID_Usuario = @ID_Usuario";
            parametros.Add(new SqlParameter("@ID_Usuario", idUsuario));

            DataTable tablaProyectos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaProyectos.Rows)
            {
                ProyectoIntegracion proyecto = new ProyectoIntegracion
                {
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                    NombreProyecto = fila["NombreProyecto"].ToString(),
                    FechaInicio = Convert.ToDateTime(fila["FechaInicio"]),
                    FechaFin = fila["FechaFin"] != DBNull.Value ? Convert.ToDateTime(fila["FechaFin"]) : (DateTime?)null,
                    Estado = Convert.ToBoolean(fila["Estado"]),
                    Cargo = fila["Cargo"].ToString()
                };
                proyectos.Add(proyecto);
            }
            return proyectos;
        }
    }

}
