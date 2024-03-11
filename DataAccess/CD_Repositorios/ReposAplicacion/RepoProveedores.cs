using Modelo;
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
    public class RepoProveedores : RepositorioMaestro
    {
        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            string consultaSQL = "SELECT * FROM proveedores"; // Ajusta esto según el nombre de tu tabla de proveedores

            DataTable tablaproveedores = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaproveedores.Rows)
            {
                Proveedor proveedor = new Proveedor
                {
                    ID_Proveedor = Convert.ToInt32(fila["ID_Proveedor"]),
                    Nombre = fila["Nombre"].ToString(),
                    Email = fila["Email"].ToString(),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"]),
                    Cuit = fila["Cuit"].ToString()
                };
                proveedores.Add(proveedor);
            }
            return proveedores;
        }
    }
}
