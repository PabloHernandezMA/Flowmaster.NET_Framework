using DataAccess.CD_Repositorios.ReposNegocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Clases
{
    public class CN_Formularios
    {
        // Instancia estática privada para almacenar la única instancia de CN_Formularios.
        private static CN_Formularios instancia;
        private RepoFormularios repositorio;
        private List<Formulario> formularios;

        // Constructor privado para evitar la creación de instancias desde fuera de la clase.
        private CN_Formularios()
        {
            repositorio = new RepoFormularios();
            formularios = new List<Formulario>();
        }

        // Método estático para obtener la instancia única de CN_Formularios.
        public static CN_Formularios ObtenerInstancia()
        {
            // Si la instancia aún no se ha creado, la creamos.
            if (instancia == null)
            {
                instancia = new CN_Formularios();
            }

            // Devolvemos la instancia existente o recién creada.
            return instancia;
        }

        public List<Formulario> ObtenerTodosLosFormularios()
        {
            try
            {
                // Si ya se han cargado los formularios previamente, los devolvemos directamente.
                if (formularios.Count > 0)
                {
                    return formularios;
                }
                else
                {
                    // Si no se han cargado previamente, los cargamos desde el repositorio y los almacenamos en memoria.
                    formularios = repositorio.ObtenerTodosLosFormularios();
                    return formularios;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw ex;
            }
        }
    }
}
