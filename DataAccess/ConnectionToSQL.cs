using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace DataAccess
{
    public class ConnectionConfig
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public abstract class ConnectionToSQL
    {
        private readonly string configFilePath = "F:\\Ingenieria de software\\Flowmaster\\DataAccess\\configSQL.json";
        private ConnectionConfig config;

        public ConnectionToSQL()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                config = JsonConvert.DeserializeObject<ConnectionConfig>(json);
            }
            else
            {
                throw new FileNotFoundException("El archivo de configuración no se encontró.");
            }
        }

        protected SqlConnection OpenConnection()
        {
            string connectionString = $"Server={config.Server};Database={config.Database};User ID={config.Username};Password={config.Password};";

            SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            return connection;
        }
    }
}
