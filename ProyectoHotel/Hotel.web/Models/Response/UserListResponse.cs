namespace Hotel.web.Models.Response
{
    public class UserListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<UserViewResult> data { get; set; }
    }

    public class UserViewResult
    {
        public int UserId { get; set; }
        public string? FullName{ get; set; }
        public string? Mail {  get; set; }
        public int UserRoleId { get; set; }
        public string? Clue { get; set; }
        public bool State {  get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}