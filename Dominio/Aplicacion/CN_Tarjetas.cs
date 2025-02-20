using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Tarjetas
    {
        private static CN_Tarjetas instancia;
        private RepoTarjetas repositorio;
        private List<Tarjeta> tarjetas;
        private CN_Tarjetas()
        {
            repositorio = new RepoTarjetas();
            tarjetas = new List<Tarjeta>();
        }

        public static CN_Tarjetas ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Tarjetas();
            }
            return instancia;
        }

        public List<Tarjeta> ObtenerTodasLasTarjetasDeLaColumna(int idColumna)
        {
            try
            {
                return repositorio.ObtenerTodasLasTarjetasDeLaColumna(idColumna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AltaTarjeta(Tarjeta tarjeta)
        {
            try
            {
                return repositorio.AltaTarjeta(tarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarTarjeta(Tarjeta tarjeta)
        {
            try
            {
                return repositorio.ModificarTarjeta(tarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int BajaTarjeta(int idTarjeta)
        {
            try
            {
                return repositorio.BajaTarjeta(idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarEmpleadoTarjetas(List<Empleado_Tarjeta> list, int idTarjeta)
        {
            try
            {
                return repositorio.ModificarEmpleadoTarjetas(list, idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TareaTarjeta> ObtenerTodasLasTareasDeLaTarjeta(int idTarjeta)
        {
            try
            {
                return repositorio.ObtenerTodasLasTareasDeLaTarjeta(idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AltaTarea(TareaTarjeta tarea)
        {
            try
            {
                return repositorio.AltaTarea(tarea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarTarea(TareaTarjeta tarea)
        {
            try
            {
                return repositorio.ModificarTarea(tarea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int BajaTarea(int idTarea)
        {
            try
            {
                return repositorio.BajaTarea(idTarea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ModificarTareaTarjetas(List<TareaTarjeta> list, int idTarjeta)
        {
            try
            {
                return repositorio.ModificarTareaTarjetas(list, idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado_Tarjeta> ObtenerTodosLosEmpleadosDeLaTarjeta(int idTarjeta)
        {
            try
            {
                return repositorio.ObtenerTodosLosEmpleadosDeLaTarjeta(idTarjeta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TareaTarjeta> ObtenerTodasLasTareasDelProyecto(int idProyecto)
        {
            try
            {
                return repositorio.ObtenerTodasLasTareasDelProyecto(idProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
