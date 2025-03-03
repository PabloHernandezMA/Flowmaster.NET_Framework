using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class AuditoriaTareaTarjeta
    {
        public int ID_Registro { get; set; }
        public string Accion { get; set; }
        public int ID_Empleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int ID_Tarea { get; set; }
        public int ID_Tarjeta { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaAccion { get; set; }
        public int ID_Columna { get; set; }
        public int ID_Proyecto { get; set; }
    }
}
