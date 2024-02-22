using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class UsuarioDA:ConnectionToSQL
    {
        public bool Login(string user, string pass)
        {
            using (var connection = OpenConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM USUARIOS WHERE Username = @username AND User_Password = @password";
                    command.Parameters.AddWithValue("username", user);
                    command.Parameters.AddWithValue("password", pass);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
