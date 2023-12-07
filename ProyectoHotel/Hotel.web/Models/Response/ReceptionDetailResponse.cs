namespace Hotel.web.Models.Response
{
    public class ReceptionDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public ReceptionViewResult data { get; set; }
    }
}
