using Hotel.domain.Entities;
using Hotel.domain.Repository;
using Hotel.infraestructure.Core;
using Hotel.infraestructure.Interfaces;
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
    public class RoomRepository : BaseRepository<Room>,IRoomRepository
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext ctx) : base(ctx) 
        {
            this._context = ctx;
        }

        public override void Save(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
        }

        public override void Update(Room entity)
        {
            var roomToUpdate = base.GetEntity(entity.RoomId);
            //modificando los valores para actualizarlo
            roomToUpdate.Price = entity.Price;
            roomToUpdate.State = entity.State;
            roomToUpdate.Detail = entity.Detail;
            roomToUpdate.CategoryId = entity.CategoryId;
            roomToUpdate.ModUserId = entity.ModUserId;
            roomToUpdate.CreationUserId = entity.CreationUserId;
            roomToUpdate.DateDeleted = entity.DateDeleted;
            roomToUpdate.RoomStateId = entity.RoomStateId;
            roomToUpdate.Removed = entity.Removed;
            roomToUpdate.DeletedUserId = entity.DeletedUserId;
            roomToUpdate.FloorId = entity.FloorId;
            //-----------------------------------
            _context.Rooms.Update(roomToUpdate);
            _context.SaveChanges();
        }
    }
}
