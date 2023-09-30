using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Client : PersonalInfo
    {
        public int IdClient { get; set; }
        public string? TypeDocument { get; set; }
        public string? Document { get; set; }


    }
}
