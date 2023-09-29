using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public abstract class PersonalInfo : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Mail { get; set; }

    }
}
