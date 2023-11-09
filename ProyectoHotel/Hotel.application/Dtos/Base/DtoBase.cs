using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Dtos.Base
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
