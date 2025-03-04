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
                string dbName = "Flowmaster";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Verificar la integridad de la base de datos antes del backup
                    string checkDbQuery = $"DBCC CHECKDB ({dbName}) WITH NO_INFOMSGS, ALL_ERRORMSGS;";
                    using (SqlCommand checkCmd = new SqlCommand(checkDbQuery, conn))
                    {
                        checkCmd.CommandTimeout = 300; // 5 minutos para bases grandes
                        checkCmd.ExecuteNonQuery();
                    }

                    // 2. Realizar el backup completo con compresión y verificación
                    string backupQuery = $@"
                BACKUP DATABASE {dbName} 
                TO DISK = '{backupPath}'
                WITH COMPRESSION, FORMAT, CHECKSUM, 
                NAME = 'Full Backup of {dbName}', 
                STATS = 10;";

                    using (SqlCommand backupCmd = new SqlCommand(backupQuery, conn))
                    {
                        backupCmd.CommandTimeout = 3600; // 1 hora para bases grandes
                        backupCmd.ExecuteNonQuery();
                    }

                    // 3. Verificar la integridad del backup generado
                    string verifyBackupQuery = $@"RESTORE VERIFYONLY FROM DISK = '{backupPath}' WITH CHECKSUM;";
                    using (SqlCommand verifyCmd = new SqlCommand(verifyBackupQuery, conn))
                    {
                        verifyCmd.CommandTimeout = 300; // 5 minutos para bases grandes
                        verifyCmd.ExecuteNonQuery();
                    }
                }

                return $"Backup realizado con éxito y verificado en: {backupPath}";
            }
            catch (Exception ex)
            {
                return $"Error al hacer el backup: {ex.Message}";
            }
        }




        public string RestaurarBackup(string backupPath)
        {
            try
            {
                string dbName = "FlowMaster";
                bool dbExiste = false;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Verificar si la base de datos existe
                    string checkDbExistsQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{dbName}';";
                    using (SqlCommand checkCmd = new SqlCommand(checkDbExistsQuery, conn))
                    {
                        dbExiste = (int)checkCmd.ExecuteScalar() > 0;
                    }

                    // 2. Si la base de datos existe, cerrar conexiones antes de restaurar
                    if (dbExiste)
                    {
                        string setSingleUser = $"USE master;ALTER DATABASE {dbName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        using (SqlCommand cmd = new SqlCommand(setSingleUser, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. Restaurar la base de datos
                    string restoreQuery = $@"USE master;
                RESTORE DATABASE {dbName} 
                FROM DISK = @backupPath
                WITH REPLACE, RECOVERY, STATS = 10, CHECKSUM;";

                    using (SqlCommand restoreCmd = new SqlCommand(restoreQuery, conn))
                    {
                        restoreCmd.Parameters.AddWithValue("@backupPath", backupPath);
                        restoreCmd.CommandTimeout = 3600; // 1 hora para bases grandes
                        restoreCmd.ExecuteNonQuery();
                    }

                    // 4. Volver a MULTI_USER (si la base existía antes)
                    if (dbExiste)
                    {
                        string setMultiUser = $"USE master; ALTER DATABASE FlowMaster SET MULTI_USER;";
                        using (SqlCommand cmd = new SqlCommand(setMultiUser, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 5. Verificar la integridad de la base restaurada
                    using (SqlCommand checkCmd = new SqlCommand($"DBCC CHECKDB ({dbName})", conn))
                    {
                        checkCmd.CommandTimeout = 300; // 5 minutos para bases grandes
                        checkCmd.ExecuteNonQuery();
                    }
                }

                return "Restauración completada con éxito y verificación de integridad realizada.";
            }
            catch (Exception ex)
            {
                return $"Error al restaurar el backup: {ex.Message}";
            }
        }

    }
}
