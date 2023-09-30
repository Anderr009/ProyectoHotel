using System;
using System.Collections.Generic;
using System.Text;
using Hotel.domain.Core;

namespace Hotel.domain.Entities
{
    public class User : PersonalInfo
    {
        public int UserID { get; set; }
        public int UserRolID { get; set; }
        public String? Password { get; set; }
    }
}
