using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Tarjeta
    {
        public int ID_Tarjeta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Posicion { get; set; }
        public bool Visible { get; set; }
        public int ID_Columna { get; set; }
    }
}
