using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoClientes : RepositorioMaestro
    {
        public List<Cliente> ObtenerTodosLosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string consultaSQL = "SELECT * FROM clientes"; // Ajusta esto según el nombre de tu tabla de clientes

            DataTable tablaClientes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaClientes.Rows)
            {
                Cliente cliente = new Cliente
                {
                    ID_Cliente = Convert.ToInt32(fila["ID_Cliente"]),
                    Nombre = fila["Nombre"].ToString(),
                    Cuit = fila["Cuit"].ToString(),
                    Abonado = Convert.ToBoolean(fila["Abonado"]),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"]),
                    ID_Ciudad = Convert.ToInt32(fila["ID_Ciudad"]),
                    ID_Provincia = Convert.ToInt32(fila["ID_Provincia"])
                };
                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}
