using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Columna
    {
        public int ID_Columna { get; set; }
        public string Nombre { get; set; }
        public int Posicion { get; set; }
        public bool Visible { get; set; }
        public int ID_Proyecto { get; set; }
    }
}
