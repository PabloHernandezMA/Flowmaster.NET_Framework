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
    public class RepoModulos : RepositorioMaestro
    {
        public List<Modulo> ObtenerTodosLosModulos()
        {
            List<Modulo> Modulos = new List<Modulo>();
            string consultaSQL = "SELECT * FROM Modulos";

            DataTable tablaModulos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaModulos.Rows)
            {
                Modulo Modulo = new Modulo
                {
                    ID_Module = Convert.ToInt32(fila["ID_Module"]),
                    ModuleName = fila["ModuleName"].ToString()
                };
                Modulos.Add(Modulo);
            }
            return Modulos;
        }
    }
}
