using Hotel.application.Core;
using Hotel.application.Dtos.Room;

namespace Hotel.web.Interface
{
    public interface IBaseHttp<DtoAdd,DtoRemove,DtoUpdate>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Post(RoomDtoAdd dtoAdd);
        ServiceResult Put(RoomDtoUpdate dtoUpdate);
    }
}
