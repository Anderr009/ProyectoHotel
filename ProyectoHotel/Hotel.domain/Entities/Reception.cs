using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Reception : BaseEntity
    {
        public int ReceptionId { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureDateConfirmation { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal Advancement { get; set; }
        public decimal RemainingPrice { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal CostPenalty { get; }
        public string? Observation { get; }
    }
}
