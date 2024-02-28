using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Dominio
{
    public class CN_Usuarios
    {
        private EUsuarios _cdUsuario;

        public CN_Usuarios()
        {
            _cdUsuario = new EUsuarios();
        }

        public DataTable MostrarUsuarios()
        {
            return _cdUsuario.Mostrar();
        }
    }
}
