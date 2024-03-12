using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Empleados
    {
        private static CN_Empleados instancia;
        private RepoEmpleados repositorio;
        private List<Empleado> empleados;

        private CN_Empleados()
        {
            repositorio = new RepoEmpleados();
            empleados = new List<Empleado>();
        }

        public static CN_Empleados ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Empleados();
            }
            return instancia;
        }

        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            try
            {
                if (empleados.Count > 0)
                {
                    return empleados;
                }
                else
                {
                    empleados = repositorio.ObtenerTodosLosEmpleados();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
