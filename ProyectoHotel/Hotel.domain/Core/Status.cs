using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public abstract class Status : BaseEntity
    {
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
