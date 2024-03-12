using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Empleado
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public int ID_User { get; set; }
        public int ID_Area { get; set; }
        public bool Habilitado { get; set; }
    }
}
