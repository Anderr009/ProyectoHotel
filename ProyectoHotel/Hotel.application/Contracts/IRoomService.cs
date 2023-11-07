using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Contracts
{
    public interface IRoomService : IBaseService<RoomDtoAdd, RoomDtoUpdate, RoomDtoRemove>
    {
    }
}
