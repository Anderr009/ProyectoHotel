using System;

namespace Hotel.application.Exceptions
{
    public class RoomServiceException : Exception
    {
        public RoomServiceException(string message) : base(message) 
        {
           
        }
    }
}
