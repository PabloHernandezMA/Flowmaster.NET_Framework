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
    public class RepoSucursales : RepositorioMaestro
    {
        public List<Sucursal> ObtenerTodasLasSucursales()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            string consultaSQL = "SELECT * FROM sucursales"; // Ajusta esto según el nombre de tu tabla de sucursales

            DataTable tablaSucursales = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaSucursales.Rows)
            {
                Sucursal sucursal = new Sucursal
                {
                    ID_Sucursal = Convert.ToInt32(fila["ID_Sucursal"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_Cliente = Convert.ToInt32(fila["ID_Cliente"]),
                    Direccion = fila["Direccion"].ToString(),
                    ID_Ciudad = Convert.ToInt32(fila["ID_Ciudad"]),
                    ID_Provincia = Convert.ToInt32(fila["ID_Provincia"]),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"])
                };
                sucursales.Add(sucursal);
            }
            return sucursales;
        }

        public List<Sucursal> ObtenerSucursalesPorCliente(int idCliente)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            string consultaSQL = "SELECT * FROM Sucursales WHERE ID_Cliente = @ID_Cliente";
            parametros.Add(new SqlParameter("@ID_Cliente", idCliente));
            DataTable tablaSucursales = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaSucursales.Rows)
            {
                Sucursal sucursal = new Sucursal
                {
                    ID_Sucursal = Convert.ToInt32(fila["ID_Sucursal"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_Cliente = Convert.ToInt32(fila["ID_Cliente"]),
                    Direccion = fila["Direccion"].ToString(),
                    ID_Ciudad = Convert.ToInt32(fila["ID_Ciudad"]),
                    ID_Provincia = Convert.ToInt32(fila["ID_Provincia"]),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"])
                };
                sucursales.Add(sucursal);
            }
            return sucursales;
        }
        public List<Sucursal> ObtenerSucursalesPorIDSucursal(int idSucursal)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            string consultaSQL = "SELECT * FROM Sucursales WHERE ID_Sucursal = @ID_Sucursal";
            parametros.Add(new SqlParameter("@ID_Sucursal", idSucursal));
            DataTable tablaSucursales = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaSucursales.Rows)
            {
                Sucursal sucursal = new Sucursal
                {
                    ID_Sucursal = Convert.ToInt32(fila["ID_Sucursal"]),
                    Nombre = fila["Nombre"].ToString(),
                    ID_Cliente = Convert.ToInt32(fila["ID_Cliente"]),
                    Direccion = fila["Direccion"].ToString(),
                    ID_Ciudad = Convert.ToInt32(fila["ID_Ciudad"]),
                    ID_Provincia = Convert.ToInt32(fila["ID_Provincia"]),
                    Habilitado = Convert.ToBoolean(fila["Habilitado"])
                };
                sucursales.Add(sucursal);
            }
            return sucursales;
        }
    }
}
