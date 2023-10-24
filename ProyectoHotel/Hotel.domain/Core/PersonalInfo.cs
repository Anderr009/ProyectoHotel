using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public class PersonalInfo : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }

    }
}
