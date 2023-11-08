using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Dtos.User
{
    public class UserDtoGet
    {
        public int UserID { get; set; }
        public int UserRoleId { get; set; }
        public string? Clue { get; set; }
        public string? Role { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
