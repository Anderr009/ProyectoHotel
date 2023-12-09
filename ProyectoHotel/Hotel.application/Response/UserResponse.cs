using System;
using System.Collections.Generic;
using System.Text;
using Hotel.application.Core;

namespace Hotel.application.Response
{
    public class UserResponse : ServiceResult
    {
        public int UserId { get; set; }
    }
}
