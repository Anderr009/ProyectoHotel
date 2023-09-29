using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public abstract class BaseEntity
    {
        public string? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
