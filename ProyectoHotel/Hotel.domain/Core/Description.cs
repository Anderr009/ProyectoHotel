using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public abstract class Description: Status
    {
        public string Descripcion { get; set; }
    }
}
