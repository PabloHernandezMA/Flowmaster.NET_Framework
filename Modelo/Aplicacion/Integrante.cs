﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Aplicacion
{
    public class Integrante
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public int ID_Proyecto { get; set; }
        public string Cargo { get; set; }
    }
}
