using Hotel.Web.Models.Responses;

namespace Hotel.Web.Models.Responses
{
    public class RolUserDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public RolUserViewResult data { get; set; }
    }
}
