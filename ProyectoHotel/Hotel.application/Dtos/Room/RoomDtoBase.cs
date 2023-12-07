using System;


namespace Hotel.application.Dtos.Room
{
    public class RoomDtoBase : DtoBase
    {
        public int RoomId { get; set; }

        public string Number { get; set; }
        public string? Detail { get; set; }
        public decimal Price { get; set; }
        public int RoomStateId { get; set; }
        public int FloorId { get; set; }
        public int CategoryId { get; set; }
    }
}
