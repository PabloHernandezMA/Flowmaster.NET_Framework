using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoProvincias : RepositorioMaestro
    {
        public List<Provincia> ObtenerTodasLasProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            string consultaSQL = "SELECT * FROM provincias"; // Ajusta esto según el nombre de tu tabla de provincias

            DataTable tablaProvincias = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaProvincias.Rows)
            {
                Provincia provincia = new Provincia
                {
                    ID_Provincia = Convert.ToInt32(fila["ID_Provincia"]),
                    Nombre = fila["Nombre"].ToString()
                };
                provincias.Add(provincia);
            }
            return provincias;
        }
    }
}
