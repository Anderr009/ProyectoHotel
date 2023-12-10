namespace Hotel.Web.Models.Response
{
    public class ClientDetailResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public ClientViewModel data { get; set; }
    }
}
