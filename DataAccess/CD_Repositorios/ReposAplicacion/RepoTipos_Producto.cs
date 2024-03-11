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
    public class RepoTipos_Producto : RepositorioMaestro
    {
        public List<Tipo_Producto> ObtenerTodosLosTipos_Producto()
        {
            List<Tipo_Producto> tipos_Producto = new List<Tipo_Producto>();
            string consultaSQL = "SELECT * FROM tipos_producto"; // Ajusta esto según el nombre de tu tabla de productos

            DataTable tablaTipos_Producto = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTipos_Producto.Rows)
            {
                Tipo_Producto tipo_Producto = new Tipo_Producto
                {
                    ID_Tipo = Convert.ToInt32(fila["ID_Tipo"]),
                    Tipo = fila["Tipo"].ToString()
                };
                tipos_Producto.Add(tipo_Producto);
            }
            return tipos_Producto;
        }
    }
}
