namespace Hotel.web.Models.Response
{
    public class RoomDetailResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public RoomViewModel data { get; set; }
       
    }
}
