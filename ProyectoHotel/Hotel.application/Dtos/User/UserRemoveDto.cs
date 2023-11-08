

using System;

namespace Hotel.application.Dtos.User
{
    public class UserRemoveDto : UserDtoBase
    {
        public int UserID { get; set; }
        public int UserDeleted { get; set; }
        public bool Removed { get; set; }
    }
}
