
using Hotel.domain.Entities;
using Hotel.domain.Repository;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        public void GetStatusRomByRoomId(Room entity);
        public void GetFloorByRoomId(Room entity);
    }
}
