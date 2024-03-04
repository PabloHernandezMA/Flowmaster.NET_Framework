using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CD_Repositorios.ReposNegocio
{
    public class RepoFormularios : RepositorioMaestro
    {
        public List<Formulario> ObtenerTodosLosFormularios()
        {
            List<Formulario> Formularios = new List<Formulario>();
            string consultaSQL = "SELECT * FROM Formularios";

            DataTable tablaFormularios = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaFormularios.Rows)
            {
                Formulario Formulario = new Formulario
                {
                    ID_Form = Convert.ToInt32(fila["ID_Form"]),
                    FormName = fila["FormName"].ToString(),
                    ID_Module = Convert.ToInt32(fila["ID_Module"])
                };
                Formularios.Add(Formulario);
            }
            return Formularios;
        }
    }
}
