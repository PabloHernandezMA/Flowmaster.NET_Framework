using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Dominio
{
    public class CN_Usuario
    {
        EUsuario usuarioDA = new EUsuario();
        public bool LoginUser(String Username, String Password)
        {
            return usuarioDA.Login(Username, Password); 
        }
    }
}
