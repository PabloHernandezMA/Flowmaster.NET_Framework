using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class TareaTarjeta
    {
        public int ID_Tarea {  get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public int ID_Tarjeta { get; set; }
    }
}
