using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public abstract class InfoPersonal : Status
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
      
    }
}
