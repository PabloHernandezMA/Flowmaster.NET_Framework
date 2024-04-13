using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Seguridad
{
    public class AuditoriaSesiones
    {
        public int ID_Auditoria { get; set; }
        public DateTime FechaHora { get; set; }
        public int TipoOperacion { get; set; }
        public int ID_User { get; set; }
        public string Username { get; set; }
    }
}
