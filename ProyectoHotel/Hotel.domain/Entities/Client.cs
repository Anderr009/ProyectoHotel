using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Client : InfoPersonal
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }


    }
}
