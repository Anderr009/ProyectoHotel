using Hotel.domain.Entities;
using Hotel.domain.Repository;
using Hotel.Infraestructure.Context;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.infraestructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {

            _context = context;
        }
        public bool Exists(Expression<Func<Room, bool>> filter)
        {
            return _context.Rooms.Any(filter);
        }


        public List<Room> GetEntities()
        {
 
            return _context.Rooms.Where(room => !room.Removed).ToList();
        }

        public Room GetEntity(int id)
        {
            return _context.Rooms.Find(id);
        }

        public void GetFloorByRoomId(Room entity)
        {
            throw new NotImplementedException();
        }

        public void GetStatusRomByRoomId(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public void Save(Room room)
        {
            _context.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            _context.Rooms.Update(room);
        }
    }
}
