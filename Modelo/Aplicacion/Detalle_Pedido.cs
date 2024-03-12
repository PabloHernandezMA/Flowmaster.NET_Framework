using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class DetallePedido
    {
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
        public float Cantidad { get; set; }
        public decimal TotalDetalle { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
