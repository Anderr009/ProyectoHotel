using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Room : BaseEntity
    {
        public int IDRoom { get; set; }
        public int Number { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
        public int IdStatusRoom { get; set; }
        public int IdFloor { get; set; }
        public int IdCategory { get; set; }
    }
}
