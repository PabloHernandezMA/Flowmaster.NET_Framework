using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Pedido
    {
        public int ID_Pedido { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Sucursal { get; set; }
        public decimal TotalPedido { get; set; }
        public int ID_Area { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionTareasRealizadas { get; set; }
        public int ID_Estado { get; set; }
    }
}
