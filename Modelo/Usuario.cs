using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string User_Password { get; set; }
        public string User_Email { get; set; }
        public bool is_Enabled { get; set; }
    }
}
