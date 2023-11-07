using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Client: PersonalInfo
    {
        public int ClientId { get; set; }
        public string? DocumentType { get; set; }
        public string? Document { get; set; }
    }
}
