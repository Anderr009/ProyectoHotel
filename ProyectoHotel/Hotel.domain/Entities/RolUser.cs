using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.domain.Entities
{
    public class RolUser : BDescription
    {
        [Key]
        public int UserRoleId { get; set; }
    }
}
