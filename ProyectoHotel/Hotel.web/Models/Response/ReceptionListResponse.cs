namespace Hotel.web.Models.Response
{
    public class ReceptionListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<ReceptionViewResult> data { get; set; }
    }

    public class ReceptionViewResult
    {
        public int receptionId { get; set; }
        public int? clientId { get; set; }
        public int? roomId { get; set; }
        public DateTime? entryDate { get; set; }
        public DateTime? departureDate { get; set; }
        public DateTime? confirmationDepartureDate { get; set; }
        public Decimal? startingPrice { get; set; }
        public Decimal? advancement { get; set; }
        public Decimal? remainingPrice { get; set; }
        public Decimal? totalPaid { get; set; }
        public Decimal? costPenalty { get; set; }
        public string? observation { get; set; }
        public bool? state { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
