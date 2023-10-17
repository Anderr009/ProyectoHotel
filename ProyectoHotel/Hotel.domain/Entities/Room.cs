using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Room : BaseEntity
    {
        public int RoomId { get; set; }
        public string Number { get; set; }
        public string? Detail { get; set; }
        public decimal Price { get; set; }
        public int RoomStateId{ get; set; }
        public int FloorId { get; set; }
        public int CategoryId { get; set; }
    }
}
