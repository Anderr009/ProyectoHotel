namespace Hotel.web.Models.Response
{
    public class UserDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public UserViewResult data { get; set; }
    }
}