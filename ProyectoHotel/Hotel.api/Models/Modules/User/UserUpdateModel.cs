using Hotel.api.Models.Core;

namespace Hotel.api.Models.Modules.User
{
    public class UserUpdateModel : UserBaseModel
    {
        public int UserId { get; set; }
    }
}
