using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Floor : BDescription
       
    {
        [Key]
        public int FloorId { get; set; }
    }
}
