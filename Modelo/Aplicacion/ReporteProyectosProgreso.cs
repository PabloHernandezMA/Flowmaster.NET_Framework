using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class ReporteProyectosProgreso
    {
        public int NumeroProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public int TotalTareas { get; set; }
        public int TareasCompletadas { get; set; }
        public int PorcentajeCompletado { get; set; }
        public int TiempoRestante { get; set; }
    }
}
