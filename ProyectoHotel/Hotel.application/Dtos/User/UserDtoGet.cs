using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Dtos.User
{
    public class UserDtoGet
    {
        public int UserID { get; set; }
        public string? FullName { get; set; }
        public string? Mail { get; set; }
        public int UserRoleId { get; set; }
        public string? Clue { get; set; }
        public bool State { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
