namespace Hotel.api.Models.Core
{
    public class UserBaseModel : ModelBase
    {
        public String? FullName { get; set; }
        public String? Mail { get; set; }
        public int UserRoleId { get; set; }
        public string? Clue { get; set; }
        public bool? State { get; set; }
    }
}
