namespace Hotel.Web.Models.Response
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public dynamic data { get; set; }
        public object message { get; set; }
       
    }
}
