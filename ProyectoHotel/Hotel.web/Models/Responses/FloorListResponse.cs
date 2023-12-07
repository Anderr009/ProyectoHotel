namespace Hotel.Web.Models.Responses
{
    public class FloorListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<FloorViewResult> data { get; set; }
    }
    public class FloorViewResult
    {
        public int floorId { get; set; }
        public bool? state { get; set; }
        public DateTime registrationDate { get; set; }
        public int creationUserId { get; set; }
    }
}
