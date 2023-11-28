using System;

namespace Hotel.Application.Extentions
{
    public static class ValidationRoomExtention
    {
        public static ServiceResult IsRoomValid(this RoomDtoBase roomDto, IConfiguration configuration)
        {
            ServiceResult result = new ServiceResult();

            return result;
        }
    }

}
