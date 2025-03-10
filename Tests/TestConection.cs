using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess;
using Newtonsoft.Json;
using Moq;

namespace DataAccess.Tests
{
    // Clase concreta para probar la clase abstracta ConnectionToSQL
    public class TestConnectionToSQL : ConnectionToSQL
    {
        // Método público para exponer el método protegido OpenConnection
        public SqlConnection TestOpenConnection()
        {
            return OpenConnection();
        }

        // Método para recargar la configuración (para pruebas)
        public void ForceLoadConfig()
        {
            // Obtener método LoadConfig por reflection
            MethodInfo loadConfigMethod = typeof(ConnectionToSQL).GetMethod("LoadConfig",
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (loadConfigMethod != null)
            {
                loadConfigMethod.Invoke(this, null);
            }
            else
            {
                throw new InvalidOperationException("No se pudo encontrar el método LoadConfig");
            }
        }

        // Obtener configuración actual
        public ConnectionConfig GetCurrentConfig()
        {
            var configField = typeof(ConnectionToSQL).GetField("config",
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (configField != null)
            {
                return configField.GetValue(this) as ConnectionConfig;
            }

            return null;
        }
    }

    [TestFixture]
    public class ConnectionToSQLTests
    {
        private string _testConfigPath;
        private string _originalAppConfigValue;
        private Configuration _configuration;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Abre el archivo de configuración actual (App.config)
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            _configuration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        [SetUp]
        public void Setup()
        {
            // Guardar valor original de SQLConfigFilePath
            _originalAppConfigValue = ConfigurationManager.AppSettings["SQLConfigFilePath"];

            // Crear un archivo de configuración para pruebas en el directorio de tests
            _testConfigPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "testConfigSQL.json");

            // Modificar el archivo App.config directamente para las pruebas
            UpdateAppConfig();
        }

        private void UpdateAppConfig()
        {
            if (_configuration != null && _configuration.AppSettings != null)
            {
                var settings = _configuration.AppSettings.Settings;
                if (settings["SQLConfigFilePath"] != null)
                {
                    settings["SQLConfigFilePath"].Value = _testConfigPath;
                }
                else
                {
                    settings.Add("SQLConfigFilePath", _testConfigPath);
                }
                _configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                // Alternativa: Usar variables de entorno como respaldo
                Environment.SetEnvironmentVariable("SQLConfigFilePath", _testConfigPath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Restaurar valor original
            if (_configuration != null && _configuration.AppSettings != null)
            {
                if (_originalAppConfigValue != null)
                {
                    _configuration.AppSettings.Settings["SQLConfigFilePath"].Value = _originalAppConfigValue;
                }
                else if (_configuration.AppSettings.Settings["SQLConfigFilePath"] != null)
                {
                    _configuration.AppSettings.Settings.Remove("SQLConfigFilePath");
                }
                _configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }

            // Limpiar variable de entorno de respaldo
            Environment.SetEnvironmentVariable("SQLConfigFilePath", null);

            // Eliminar archivo de prueba
            if (File.Exists(_testConfigPath))
            {
                File.Delete(_testConfigPath);
            }
        }

        // PRUEBAS EXISTENTES

        [Test]
        public void LoadConfig_ConfigFileExists_LoadsConfiguration()
        {
            // Arrange - Crear archivo de configuración para pruebas
            var configData = new ConnectionConfig
            {
                Server = "testserver",
                Database = "testdb",
                Username = "testuser",
                Password = "testpass"
            };

            string jsonConfig = JsonConvert.SerializeObject(configData);
            File.WriteAllText(_testConfigPath, jsonConfig);

            try
            {
                // Act
                var connection = new TestConnectionToSQL();

                // Verificar que se haya cargado la configuración correctamente
                var config = connection.GetCurrentConfig();

                // Assert
                Assert.That(config, Is.Not.Null, "La configuración no se cargó correctamente");
                Assert.That(config.Server, Is.EqualTo("testserver"));
                Assert.That(config.Database, Is.EqualTo("testdb"));
                Assert.That(config.Username, Is.EqualTo("testuser"));
                Assert.That(config.Password, Is.EqualTo("testpass"));
            }
            catch (Exception ex)
            {
                Assert.Fail($"La prueba falló con excepción: {ex.Message}\nDetalles: {ex.StackTrace}");
            }
        }

        [Test]
        public void OpenConnection_ValidConfig_ReturnsValidConnection()
        {
            // Arrange - Crear archivo de configuración para pruebas
            var configData = new ConnectionConfig
            {
                Server = "DESKTOP-K8DS49N",
                Database = "Flowmaster",
                Username = "FlowmasterAdmin",
                Password = "FlowmasterAdmin123"
            };

            string jsonConfig = JsonConvert.SerializeObject(configData);
            File.WriteAllText(_testConfigPath, jsonConfig);

            try
            {
                // Act
                var connection = new TestConnectionToSQL();
                var sqlConnection = connection.TestOpenConnection();

                // Assert
                Assert.That(sqlConnection, Is.Not.Null, "La conexión SQL no se creó correctamente");
                Assert.That(sqlConnection.ConnectionString, Does.Contain("Server=DESKTOP-K8DS49N"));
                Assert.That(sqlConnection.ConnectionString, Does.Contain("Database=Flowmaster"));
                Assert.That(sqlConnection.ConnectionString, Does.Contain("User ID=FlowmasterAdmin"));
                //Assert.That(sqlConnection.ConnectionString, Does.Contain("Password=FlowmasterAdmin123")); Se oculta por razones de seguridad asique no se puede leer
            }
            catch (Exception ex)
            {
                Assert.Fail($"La prueba falló con excepción: {ex.Message}\nDetalles: {ex.StackTrace}");
            }
        }

        [Test]
        public void Constructor_ThrowsExceptionWhenConfigFileNotFound()
        {
            // Arrange - Aseguramos que el archivo de prueba no existe
            if (File.Exists(_testConfigPath))
            {
                File.Delete(_testConfigPath);
            }

            // Act & Assert
            Assert.That(() => new TestConnectionToSQL(), Throws.TypeOf<FileNotFoundException>()
                .With.Message.Contains("El archivo de configuración de la base de datos no se encontró"));
        }

        // NUEVAS PRUEBAS BASADAS EN PARTICIÓN EQUIVALENTE

        [Test]
        public void LoadConfig_InvalidJsonFormat_ThrowsException()
        {
            // Arrange - Crear archivo de configuración inválido
            File.WriteAllText(_testConfigPath, "{ invalid json }");

            // Act & Assert
            Assert.That(() => new TestConnectionToSQL(), Throws.TypeOf<JsonReaderException>()
                .Or.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void OpenConnection_ServerNotFound_ThrowsSqlException()
        {
            // Arrange - Crear archivo con servidor inexistente
            var configData = new ConnectionConfig
            {
                Server = "nonexistentserver",
                Database = "testdb",
                Username = "testuser",
                Password = "testpass"
            };

            string jsonConfig = JsonConvert.SerializeObject(configData);
            File.WriteAllText(_testConfigPath, jsonConfig);

            // Act & Assert
            var connection = new TestConnectionToSQL();
            Assert.That(() => connection.TestOpenConnection(), Throws.TypeOf<SqlException>());
            // En un entorno real podríamos verificar el código de error específico
            // .With.Property("Number").EqualTo(53)); // Error 53: server not found
        }

        // NUEVAS PRUEBAS BASADAS EN ANÁLISIS DE VALORES LÍMITE

        [Test]
        public void OpenConnection_ExtremelyLongServerName_ThrowsException()
        {
            // Arrange - Crear configuración con nombre de servidor muy largo
            var configData = new ConnectionConfig
            {
                Server = new string('a', 300), // 300 caracteres
                Database = "testdb",
                Username = "testuser",
                Password = "testpass"
            };

            string jsonConfig = JsonConvert.SerializeObject(configData);
            File.WriteAllText(_testConfigPath, jsonConfig);

            // Act & Assert
            var connection = new TestConnectionToSQL();
            Assert.That(() => connection.TestOpenConnection(), Throws.Exception);
        }

        [Test]
        public void OpenConnection_EmptyCredentials_ThrowsSqlException()
        {
            // Arrange - Crear configuración con credenciales vacías
            var configData = new ConnectionConfig
            {
                Server = "testserver",
                Database = "testdb",
                Username = "",
                Password = ""
            };

            string jsonConfig = JsonConvert.SerializeObject(configData);
            File.WriteAllText(_testConfigPath, jsonConfig);

            // Act & Assert
            var connection = new TestConnectionToSQL();
            Assert.That(() => connection.TestOpenConnection(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void LoadConfig_MissingRequiredFields_ThrowsException()
        {
            // Arrange - Crear configuración incompleta
            var configData = new ConnectionConfig
            {
                Server = "testserver",
                // Sin base de datos
                Username = "testuser",
                Password = "testpass"
            };

            string jsonConfig = JsonConvert.SerializeObject(configData);
            File.WriteAllText(_testConfigPath, jsonConfig);

            // Act & Assert
            var connection = new TestConnectionToSQL();
            Assert.That(() => connection.TestOpenConnection(), Throws.Exception);
        }
    }
}