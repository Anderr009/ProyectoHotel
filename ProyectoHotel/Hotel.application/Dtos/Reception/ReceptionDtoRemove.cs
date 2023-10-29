using System;
using System.Collections.Generic;
using System.Text;
using Hotel.application.Dtos.Base;

namespace Hotel.application.Dtos.Reception
{
    public class ReceptionDtoRemove : DtoBase
    {
        public int ReceptionId { get; set; }
        public bool Removed { get; set; }
    }
}
