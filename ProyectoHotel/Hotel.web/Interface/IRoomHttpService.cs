using Hotel.application.Dtos.Room;
using Hotel.web.Models.Response;

namespace Hotel.web.Interface
{
    public interface IRoomHttpService : IBaseHttp<RoomDtoAdd,RoomDtoRemove,RoomDtoUpdate>
    {
    }
}
