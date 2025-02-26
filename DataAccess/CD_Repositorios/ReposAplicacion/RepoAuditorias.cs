using Modelo.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CD_Repositorios.ReposAplicacion
{
    public class RepoAuditorias : RepositorioMaestro
    {
        public List<Tarjeta> ObtenerTodasLasTarjetasDeLaColumna(int idColumna)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            string consultaSQL = "SELECT * FROM TARJETAS WHERE ID_Columna = @ID_Columna ORDER BY Posicion";
            parametros.Add(new SqlParameter("@ID_Columna", idColumna));

            DataTable tablaTarjetas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTarjetas.Rows)
            {
                Tarjeta tarjeta = new Tarjeta
                {
                    ID_Tarjeta = Convert.ToInt32(fila["ID_Tarjeta"]),
                    Nombre = fila["Nombre"].ToString(),
                    Descripcion = fila["Descripcion"] != DBNull.Value ? fila["Descripcion"].ToString() : null,
                    Posicion = Convert.ToInt32(fila["Posicion"]),
                    Visible = Convert.ToBoolean(fila["Visible"]),
                    ID_Columna = Convert.ToInt32(fila["ID_Columna"])
                };
                tarjetas.Add(tarjeta);
            }
            return tarjetas;
        }
    }
}
