using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using Hotel.application.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Hotel.Application.Extentions
{
    public static class ValidationRoomExtention
    {
        public static ServiceResult IsRoomValid(this RoomDtoBase roomDto, IConfiguration configuration)
        {
            //utilice estos campos porque no aparecian not nulls en mi tabla, me tome la libertad
            //de usar estos dos con motivos de aprendizaje espero no sea un problema
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(roomDto.Detail))
            {
                throw new RoomServiceException(configuration["MensajeValidaciones:RoomDetail"]);
            }
            if(roomDto.Detail.Length > 100) 
            {
                throw new RoomServiceException(configuration["MensajeValidaciones:RoomDetail"]);
            }
            if(roomDto.Price < 0)
            {
                throw new RoomServiceException(configuration["MensajeValidaciones:RoomPrice"]);

            }
            return result;
        }
    }

}

