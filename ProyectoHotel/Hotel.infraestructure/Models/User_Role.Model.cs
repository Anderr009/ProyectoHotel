﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.infraestructure.Models
{
    public class User_RoleModel
    {
        public int UserID { get; set; }
        public String? FullName { get; set; }
        public string? Mail {  get; set; }
        public int UserRoleId { get; set; }
        public string? Clue { get; set; }
        public string? Role { get; set; }
        public DateTime? RegistratonDate { get; set; }
    }
}
