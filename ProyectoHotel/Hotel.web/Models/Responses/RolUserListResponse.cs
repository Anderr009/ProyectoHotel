

namespace Hotel.Web.Models.Responses
{
    public class RolUserListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<RolUserViewResult> data { get; set; }
    }

    public class RolUserViewResult
    {
        public string description { get; set; }
        public int userRoleId { get; set; }
        public bool? state { get; set; }
        public DateTime registrationDate { get; set; }
        public int creationUserId { get; set; }
    }
}
