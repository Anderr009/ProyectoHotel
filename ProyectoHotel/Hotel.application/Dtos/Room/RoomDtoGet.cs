using System;


namespace Hotel.application.Dtos.Room
{
    public class RoomDtoGet : RoomDtoBase
    {

        public string? RoomState { get; set; }

        public string? Floor { get; set; }

        public string? Category { get; set; }
    }
}
