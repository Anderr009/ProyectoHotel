
using Hotel.application.Dtos.Base;

namespace Hotel.application.Dtos.User
{
    public abstract class UserDtoBase : DtoBase
    {
        public string? FullName { get; set; }
        public string? Mail { get; set; }
        public int UserRoleId { get; set; }
        public string? Clue { get; set; }
        public bool State {  get; set; }
    }
}
