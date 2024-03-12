using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoEmpleados : RepositorioMaestro
    {
        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            string consultaSQL = "SELECT * FROM empleados"; // Ajusta esto según el nombre de tu tabla de empleados

            DataTable tablaEmpleados = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEmpleados.Rows)
            {
                Empleado empleado = new Empleado
                {
                    ID_Empleado = Convert.ToInt32(fila["ID_Empleado"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_User = Convert.ToInt32(fila["ID_User"]),
                    ID_Area = Convert.ToInt32(fila["ID_Area"]),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"])
                };
                empleados.Add(empleado);
            }
            return empleados;
        }
    }
