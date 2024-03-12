using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Producto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public int ID_Categoria { get; set; }
        public int ID_Tipo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Existencias { get; set; }
        public bool Habilitado { get; set; }
        public int StockMinimo { get; set; }
        public int ID_Proveedor { get; set; }
    }
}