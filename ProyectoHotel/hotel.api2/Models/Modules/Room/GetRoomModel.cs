namespace hotel.api.Models.Modules.Room
{
    public class GetRoomModel
    {
        public int RoomId { get; set; }
        public string Number { get; set; }
        public string? Detail { get; set; }
        public decimal Price { get; set; }

    }
}
