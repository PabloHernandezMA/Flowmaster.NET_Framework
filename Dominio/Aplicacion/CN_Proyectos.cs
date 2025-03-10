﻿using DataAccess.CD_Repositorios.ReposAplicacion;
using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class CN_Proyectos
    {
        private static CN_Proyectos instancia;
        private RepoProyectos repositorio;
        private List<Proyecto> proyectos;
        private List<Integrante> integrantes;

        private CN_Proyectos()
        {
            repositorio = new RepoProyectos();
            integrantes = new List<Integrante>();
            proyectos = new List<Proyecto>();
        }

        public static CN_Proyectos ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new CN_Proyectos();
            }
            return instancia;
        }
        public List<Proyecto> ObtenerTodosLosProyectos()
        {
            try
            {
                proyectos = repositorio.ObtenerTodosLosProyectos();
                return proyectos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Proyecto ObtenerProyecto(int idProyecto)
        {
            proyectos = repositorio.ObtenerTodosLosProyectos();
            Proyecto proyectoBuscado = proyectos.FirstOrDefault(p => p.ID_Proyecto == idProyecto);
            return proyectoBuscado;
        }
        public int AltaProyecto(Proyecto proyecto)
        {
            try
            {
                return repositorio.AltaProyecto(proyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método adicional: Baja de un proyecto (ejemplo)
        public int BajaProyecto(int idProyecto)
        {
            try
            {
                return repositorio.BajaProyecto(idProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método adicional: Modificación de un proyecto (ejemplo)
        public int ModificarProyecto(Proyecto proyecto)
        {
            try
            {
                return repositorio.ModificarProyecto(proyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Proyecto> ObtenerTodosLosProyectosEnLosQueParticipaUnEmpleado(int idEmpleado)
        {
            try
            {
                proyectos = repositorio.ObtenerTodosLosProyectosEnLosQueParticipaUnEmpleado(idEmpleado);
                return proyectos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Integrante> ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(int idProyecto)
        {
            try
            {
                integrantes = repositorio.ObtenerTodosLosIntegrantesDeUnProyectoYSusCargos(idProyecto);
                return integrantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ModificarEmpleadosxProyecto(List<Integrante> integrantes, int idProyecto)
        {
            try
            {
                return repositorio.ModificarEmpleadosxProyecto(integrantes, idProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteProyectosProgreso> ObtenerProgresoProyectos(DateTime fechaDesde, string estado)
        {
            try
            {
                return repositorio.ObtenerProgresoProyectos(fechaDesde, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PEDIDOxPROYECTO> ObtenerPEDIDOSxPROYECTO(int idProyecto)
        {
            try
            {
                return repositorio.ObtenerPEDIDOxPROYECTO(idProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AltaPEDIDOxPROYECTO(PEDIDOxPROYECTO pedido)
        {
            try
            {
                return repositorio.AltaPEDIDOxPROYECTO(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int BajaPEDIDOxPROYECTO(PEDIDOxPROYECTO pedido)
        {
            try
            {
                return repositorio.BajaPEDIDOxPROYECTO(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ModificarPEDIDOxPROYECTO(List<PEDIDOxPROYECTO> pedido, int idProyecto)
        {
            try
            {
                return repositorio.ModificarPEDIDOxPROYECTO(pedido, idProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
