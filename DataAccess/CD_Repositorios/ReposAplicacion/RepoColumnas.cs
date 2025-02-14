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
    public class RepoColumnas : RepositorioMaestro
    {
        public List<Columna> ObtenerTodosLasColumnas()
        {
            List<Columna> columnas = new List<Columna>();
            string consultaSQL = "SELECT * FROM columnas"; // Ajusta esto según el nombre de tu tabla de pedidos

            DataTable tablaPedidos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPedidos.Rows)
            {
                Columna columna = new Columna
                {
                    ID_Columna = Convert.ToInt32(fila["ID_Columna"]),
                    Nombre = fila["Nombre"].ToString(),
                    Posicion = Convert.ToInt32(fila["Posicion"]),
                    Visible = Convert.ToBoolean(fila["Visible"]),
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"]),
                };
                columnas.Add(columna);
            }
            return columnas;
        }
        public List<Columna> ObtenerTodasLasColumnasDelProyecto(int idProyecto)
        {
            List<Columna> columnas = new List<Columna>();
            string consultaSQL = "SELECT * FROM COLUMNAS WHERE ID_Proyecto = @ID_Proyecto ORDER BY Posicion";
            parametros.Add(new SqlParameter("@ID_Proyecto", idProyecto));

            DataTable tablaColumnas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaColumnas.Rows)
            {
                Columna columna = new Columna
                {
                    ID_Columna = Convert.ToInt32(fila["ID_Columna"]),
                    Nombre = fila["Nombre"].ToString(),
                    Posicion = Convert.ToInt32(fila["Posicion"]),
                    Visible = Convert.ToBoolean(fila["Visible"]),
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"])
                };
                columnas.Add(columna);
            }
            return columnas;
        }
        public List<Columna> ObtenerTodasLasColumnasDelProyectoPorTarjeta(int idTarjeta)
        {
            List<Columna> columnas = new List<Columna>();
            string consultaSQL = "SELECT c.* FROM COLUMNAS c WHERE c.ID_Proyecto = (SELECT c2.ID_Proyecto FROM COLUMNAS c2 JOIN TARJETAS t ON c2.ID_Columna = t.ID_Columna WHERE t.ID_Tarjeta = @ID_Tarjeta)";
            parametros.Add(new SqlParameter("@ID_Tarjeta", idTarjeta));

            DataTable tablaColumnas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaColumnas.Rows)
            {
                Columna columna = new Columna
                {
                    ID_Columna = Convert.ToInt32(fila["ID_Columna"]),
                    Nombre = fila["Nombre"].ToString(),
                    Posicion = Convert.ToInt32(fila["Posicion"]),
                    Visible = Convert.ToBoolean(fila["Visible"]),
                    ID_Proyecto = Convert.ToInt32(fila["ID_Proyecto"])
                };
                columnas.Add(columna);
            }
            return columnas;
        }
        public int AltaColumna(Columna columna)
        {
            string consultaSQL = @"INSERT INTO COLUMNAS (Nombre, Posicion, Visible, ID_Proyecto)
                               VALUES (@Nombre, @Posicion, @Visible, @ID_Proyecto)";
            parametros.Add(new SqlParameter("@Nombre", columna.Nombre));
            parametros.Add(new SqlParameter("@Posicion", columna.Posicion));
            parametros.Add(new SqlParameter("@Visible", columna.Visible));
            parametros.Add(new SqlParameter("@ID_Proyecto", columna.ID_Proyecto));

            return ExecuteNonQuery(consultaSQL);
        }

        public int BajaColumna(int idColumna)
        {
            string consultaSQL = @"DELETE FROM EMPLEADOxTARJETA
                                    WHERE ID_Tarjeta IN (SELECT ID_Tarjeta FROM TARJETAS WHERE ID_Columna = @ID_Columna);
                                    DELETE FROM TARJETAS WHERE ID_Columna = @ID_Columna;
                                    DELETE FROM COLUMNAS WHERE ID_Columna = @ID_Columna";
            parametros.Add(new SqlParameter("@ID_Columna", idColumna));
            return ExecuteNonQuery(consultaSQL);
        }

        public int ModificarColumna(Columna columna)
        {
            string consultaSQL = @"UPDATE COLUMNAS
                               SET Nombre = @Nombre,
                                   Posicion = @Posicion,
                                   Visible = @Visible
                               WHERE ID_Columna = @ID_Columna";
            parametros.Add(new SqlParameter("@Nombre", columna.Nombre));
            parametros.Add(new SqlParameter("@Posicion", columna.Posicion));
            parametros.Add(new SqlParameter("@Visible", columna.Visible));
            parametros.Add(new SqlParameter("@ID_Columna", columna.ID_Columna));

            return ExecuteNonQuery(consultaSQL);
        }
    }
}
