using System;

namespace Hotel.application.Exceptions
{
    public class UserServiceExceptions : Exception
    {
        public UserServiceExceptions(string message) : base(message) 
        {

        }
    }
}
