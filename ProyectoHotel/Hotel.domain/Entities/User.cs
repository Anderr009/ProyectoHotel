using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class User : InfoPersonal
    {
        public int IdUsuario { get; set; }
        public int IdRolUsuario { get; set; }
        public string Clave { get; set; }

        public string Estado { get; set; }
       
    }
}
