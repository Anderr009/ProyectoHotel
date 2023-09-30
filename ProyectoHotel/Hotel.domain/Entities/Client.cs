using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Client : BaseEntity
    {
        public int IdClient { get; set; }
        public string? FullName { get; set; }
        public string? TypeDocument { get; set; }
        public string? Document { get; set; }\
        public string? Email { get; set; }
        public DateTime? Datecreation { get; set; }




    }
}
