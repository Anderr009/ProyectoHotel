using hotel.api.Models.Modules.Core;

namespace hotel.api.Models.Modules.Room
{
    public abstract class RoomBaseModel : ModelBase
    {
        public string Number { get; set; }

        public string? Detail { get; set; }
        public decimal Price { get; set; }
        public int RoomStateId { get; set; }
        public int FloorId { get; set; }
        public int CategoryId { get; set; }
        public bool State { get; set; }
        public int ModUserId { get; set; }
    }
}
