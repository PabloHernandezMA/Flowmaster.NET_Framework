using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Proyecto
    {
        public int ID_Proyecto { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }
    public class PEDIDOxPROYECTO
    {
        public int ID_Pedido { get; set; }
        public int ID_Proyecto { get; set; }
    }
}
