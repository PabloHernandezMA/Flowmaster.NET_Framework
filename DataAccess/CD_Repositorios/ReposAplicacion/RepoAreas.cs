using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    Nombre = fila["Nombre"].ToString()
                };
                areas.Add(area);
            }
            return areas;
        }

        public List<Area> ObtenerAreasPorIDPedido(int idPedido)
        {
            List<Area> areas = new List<Area>();
            string consultaSQL = "SELECT A.* FROM Areas A INNER JOIN Pedidos P ON A.ID_Area = P.ID_Area WHERE P.ID_Pedido = @ID_Pedido";
            parametros.Add(new SqlParameter("@ID_Pedido", idPedido));
            DataTable tablaAreas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAreas.Rows)
            {
                Area area = new Area
                {
                    ID_Area = Convert.ToInt32(fila["ID_Area"]),
                    Nombre = fila["Nombre"].ToString() 
                };
                areas.Add(area);
            }
            return areas;
        }

        public List<Area> ObtenerAreasPorIDEmpleado(int idEmpleado)
        {
            List<Area> areas = new List<Area>();
            string consultaSQL = "SELECT A.* FROM Areas A INNER JOIN Empleados E ON A.ID_Area = E.ID_Area WHERE E.ID_Empleado = @ID_Empleado";
            parametros.Add(new SqlParameter("@ID_Empleado", idEmpleado));
            DataTable tablaAreas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaAreas.Rows)
            {
                Area area = new Area
                {
                    ID_Area = Convert.ToInt32(fila["ID_Area"]),
                    Nombre = fila["Nombre"].ToString() // Ajusta este campo según tu modelo de datos
                };
                areas.Add(area);
            }
            return areas;
        }
    }
}
