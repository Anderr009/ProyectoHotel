
using Hotel.domain.Entities;
using System.Linq.Expressions;
using System;

namespace Hotel.domain.Repository
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        public void GetStatusRomByRoomId(Room entity);
        public void GetFloorByRoomId(Room entity);
        bool Exists(Expression<Func<Room, bool>> filter);

    }
}
