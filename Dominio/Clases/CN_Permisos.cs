﻿using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Clases
{
    public class CN_Permisos
    {
        private List<Permiso> permisos;

        // Instancia estática privada para almacenar la única instancia de CN_Usuarios.
        private static CN_Permisos instancia;

        // Repositorio de usuarios
        private RepoPermisos repositorioPermisos;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Permisos()
        {
            repositorioPermisos = new RepoPermisos();
        }

        // Método estático para obtener la instancia única de CN_Usuarios.
        public static CN_Permisos ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Permisos();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Permiso> ObtenerTodosLosPermisos()
        {
            try
            {
                permisos = repositorioPermisos.ObtenerTodosLosPermisos();
                return permisos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Permiso> ObtenerPermisosDeUsuario(int userID)
        {
            try
            {
                permisos = repositorioPermisos.ObtenerPermisosDeUsuario(userID);
                return permisos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }

        public List<Permiso> ObtenerPermisosDeGruposPorID_User(int userID)
        {
            try
            {
                permisos = repositorioPermisos.ObtenerPermisosDeGruposPorID_User(userID);
                return permisos;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
