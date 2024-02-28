using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class EUsuarios : ConnectionToSQL
    {
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string User_Password { get; set; }
        public string User_Email { get; set; }
        public bool is_Enabled { get; set; }


        public DataTable Mostrar()
        {
            DataTable dataTable = new DataTable();
            using (var connection = OpenConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM USUARIOS";
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }
    }
}
