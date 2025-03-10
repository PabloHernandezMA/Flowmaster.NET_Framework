using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

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
        private readonly string configFilePath = ConfigurationManager.AppSettings["SQLConfigFilePath"];
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

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error
                };

                try
                {
                    config = JsonConvert.DeserializeObject<ConnectionConfig>(json, settings);
                }
                catch (JsonSerializationException ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error al deserializar el archivo de configuración: " + ex.Message);
                    return;
                }
            }
            else if (File.Exists("C:\\UAI\\Flowmaster.NET_Framework\\DataAccess\\configSQL.json"))
            {
                string json = File.ReadAllText("C:\\UAI\\Flowmaster.NET_Framework\\DataAccess\\configSQL.json");
                config = JsonConvert.DeserializeObject<ConnectionConfig>(json);
            }
            else
            {
                throw new FileNotFoundException("El archivo de configuración de la base de datos no se encontró.");
            }
        }

        protected SqlConnection OpenConnection()
        {
            // Verificar si los campos necesarios están completos
            if (string.IsNullOrWhiteSpace(config.Server))
            {
                throw new InvalidOperationException("El campo 'Server' está vacío o no se ha definido.");
            }

            if (string.IsNullOrWhiteSpace(config.Database))
            {
                throw new InvalidOperationException("El campo 'Database' está vacío o no se ha definido.");
            }

            if (string.IsNullOrWhiteSpace(config.Username))
            {
                throw new InvalidOperationException("El campo 'Username' está vacío o no se ha definido.");
            }

            if (string.IsNullOrWhiteSpace(config.Password))
            {
                throw new InvalidOperationException("El campo 'Password' está vacío o no se ha definido.");
            }

            string connectionString = $"Server={config.Server};Database={config.Database};User ID={config.Username};Password={config.Password};";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Intenta abrir la conexión
                                   // Aquí puedes realizar otras pruebas si es necesario
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return connection;
        }
    }
}
