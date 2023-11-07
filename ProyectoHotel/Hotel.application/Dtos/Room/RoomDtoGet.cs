using System;


namespace Hotel.application.Dtos.Room
{
    public class RoomDtoGet
    {
        public string Number { get; set; }
        public string? Detail { get; set; }
        public decimal Price { get; set; }
        public int RoomStateId { get; set; }

        public string? RoomState { get; set; }
        public int FloorId { get; set; }

        public string? Floor { get; set; }
        public int CategoryId { get; set; }

        public string? Category { get; set; }
    }
}
