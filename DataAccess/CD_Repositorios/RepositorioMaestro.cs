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
        protected List<SqlParameter> parametros;

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
                    SqlDataReader reader = command.ExecuteReader();
                    using(var table  = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }
                }
            }
        }
    }
}
