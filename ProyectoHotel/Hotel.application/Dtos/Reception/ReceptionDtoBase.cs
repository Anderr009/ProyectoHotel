using System;
using System.Collections.Generic;
using System.Text;
using Hotel.application.Dtos.Base;

namespace Hotel.application.Dtos.Reception
{
    public abstract class ReceptionDtoBase: DtoBase
    {
        public int? ClientId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ConfirmationDepartureDate { get; set; }
        public decimal? StartingPrice { get; set; }
        public decimal? Advancement { get; set; }
        public decimal? RemainingPrice { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? CostPenalty { get; set; }
        public string? Observation { get; set; }
        public bool? State { get; set; }
    }
}
