using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Core
{
    public abstract class BaseEntity
    {
        public DateTime RecordDate { get; set; }
        public int CreationUserId { get; set; }
        public DateTime DateMod { get; set; }
        public int ModUserId { get; set; }
        public int UserIdDelete { get; set; }
        public DateTime DateRemove { get; set; }
        public bool Removed { get; set; }
    }
}
