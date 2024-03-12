using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoAreas : RepositorioMaestro
    {
        public List<Area> ObtenerTodasLasAreas()
        {
            List<Area> areas = new List<Area>();
            string consultaSQL = "SELECT * FROM areas"; // Ajusta esto según el nombre de tu tabla de áreas

            DataTable tablaAreas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAreas.Rows)
            {
                Area area = new Area
                {
                    ID_Area = Convert.ToInt32(fila["ID_Area"]),
                    Nombre = fila["Area"].ToString() // Asegúrate de tener esta columna en tu tabla de áreas
                };
                areas.Add(area);
            }
            return areas;
        }
    }
}
