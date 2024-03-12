using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoCiudades : RepositorioMaestro
    {
        public List<Ciudad> ObtenerTodasLasCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            string consultaSQL = "SELECT * FROM ciudades"; // Ajusta esto según el nombre de tu tabla de ciudades

            DataTable tablaCiudades = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaCiudades.Rows)
            {
                Ciudad ciudad = new Ciudad
                {
                    ID_Ciudad = Convert.ToInt32(fila["ID_Ciudad"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_Provincia = Convert.ToInt32(fila["ID_Provincia"]) // Asegúrate de tener esta columna en tu tabla de ciudades
                };
                ciudades.Add(ciudad);
            }
            return ciudades;
        }
    }
}
