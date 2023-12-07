using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.web.Models.Response
{
    public class RoomListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<RoomViewModel> data { get; set; }
    }
    public class RoomViewModel
    {
        public object roomState { get; set; }
        public object floor { get; set; }
        public object category { get; set; }
        public int roomId { get; set; }
        public string number { get; set; }
        public string detail { get; set; }
        public double price { get; set; }
        public int roomStateId { get; set; }
        public int floorId { get; set; }
        public int categoryId { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
    }



}
