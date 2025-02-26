using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace Dominio.Aplicacion
{
    public class ClassDataBase
    {
        private static ClassDataBase instancia;
        private string connectionString;

        private ClassDataBase()
        {
            connectionString = ObtenerDatos();
        }

        public static ClassDataBase ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new ClassDataBase();
            }
            return instancia;
        }

        public string ObtenerDatos()
        {
            try
            {
                //string path = "./DataAccess/configSQL.json";
                string path = ConfigurationManager.AppSettings["SQLConfigFilePath"];
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    dynamic config = JsonConvert.DeserializeObject(json);
                    string connString = $"Server={config.Server};Database={config.Database};User Id={config.Username};Password={config.Password};";
                    return connString;
                }
                else
                {
                    throw new FileNotFoundException("El archivo de configuración no existe.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los datos: {ex.Message}");
            }
        }

        public bool Conectar()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ProbarConexion()
        {
            return Conectar();
        }

        public string HacerBackup(string backupPath)
        {
            try
            {
                string query = $"BACKUP DATABASE Flowmaster TO DISK='{backupPath}'";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        return $"Backup realizado con éxito en: {backupPath}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al hacer el backup: {ex.Message}";
            }
        }
    }
}
