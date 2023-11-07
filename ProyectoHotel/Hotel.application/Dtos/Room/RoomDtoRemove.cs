using System;


namespace Hotel.application.Dtos.Room
{
    public class RoomDtoRemove : RoomDtoBase
    {
        public bool Removed { get; set; }
        public int RoomId { get; set; }

    }
}
