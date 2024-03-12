using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Sucursal
    {
        public int ID_Sucursal { get; set; }
        public string Nombre { get; set; }
        public int ID_Cliente { get; set; }
        public string Direccion { get; set; }
        public int ID_Ciudad { get; set; }
        public int ID_Provincia { get; set; }
        public bool Habilitado { get; set; }
    }
}
