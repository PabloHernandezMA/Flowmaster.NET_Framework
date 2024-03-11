using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Proveedor
    {
        public int ID_Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public string Cuit { get; set; }
    }
}
