using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CD_Repositorios
{
    public abstract class RepositorioMaestro:ConnectionToSQL
    {
        protected static List<SqlParameter> parametros;

        protected RepositorioMaestro()
        {
            if (parametros == null)
            {
                parametros = new List<SqlParameter>(); // Solo se inicializa si es la primera instancia
            }
        }

        protected int ExecuteNonQuery(string transaccionSQL) 
        { 
            using (var connection = OpenConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transaccionSQL;
                    command.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parametros.Clear();
                    return result;
                }
            }
        }

        protected DataTable ExecuteReader(string transaccionSQL)
        {
            using (var connection = OpenConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transaccionSQL;
                    command.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        command.Parameters.Add(item);
                    }
                    SqlDataReader reader = command.ExecuteReader();
                    using(var table  = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        parametros.Clear(); // Limpiar la lista de parámetros
                        return table;
                    }
                }
            }
        }
    }
}
