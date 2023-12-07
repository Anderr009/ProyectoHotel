namespace Hotel.Web.Models.Responses
{
    public class FloorDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public FloorViewResult data { get; set; }
    }
}
