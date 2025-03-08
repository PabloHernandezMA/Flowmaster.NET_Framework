using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Factura
    {
        public float Cantidad { get; set; }
        public decimal TotalDetalle { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Nombre_Producto { get; set; }
    }
}
