﻿using Hotel.application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Dtos.Reception
{
    public class FloorDtoBase : DtoBase
    {
        public int FloorId { get; set; }
        public bool? State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CreationUserId { get; set; }
        public DateTime? ModDate { get; set; }
        public int? ModUserId { get; set; }
        public int? DeletedUserId { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool Removed { get; set; }
    }
}
