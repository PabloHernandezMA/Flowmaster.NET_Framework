using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class RepoUsuario:ConnectionToSQL
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
                    command.CommandText = "SELECT * FROM USUARIOS WHERE Username COLLATE Latin1_General_CS_AS = @username COLLATE Latin1_General_CS_AS AND User_Password COLLATE Latin1_General_CS_AS = @password COLLATE Latin1_General_CS_AS;";
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
