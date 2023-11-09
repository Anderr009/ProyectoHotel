
using System;

namespace Hotel.application.Dtos.Client
{
    public class ClientDtoRemove
    {
        public int ClientId { get; set; }
        public int? DeletedUserId { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool Removed { get; set; }
    }
}
