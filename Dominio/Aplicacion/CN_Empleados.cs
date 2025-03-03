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
                return repositorio.ObtenerTodosLosEmpleados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Empleado> ObtenerEmpleadosPorIDEmpleado(int idEmpleado)
        {
            try
            {
                return repositorio.ObtenerEmpleadosPorIDEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Empleado ObtenerEmpleadoPorIdUsuario(int idUsuario)
        {
            try
            {
                return repositorio.ObtenerEmpleadoPorIdUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado> ObtenerEmpleadosAsociadosAPedido(int idPedido)
        {
            try
            {
                return repositorio.ObtenerEmpleadosAsociadosAPedido(idPedido);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
