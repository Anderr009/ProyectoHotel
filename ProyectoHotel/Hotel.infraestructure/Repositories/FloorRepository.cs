using Hotel.domain.Entities;
using Hotel.infraestructure.Context;
using Hotel.infraestructure.Core;
using Hotel.infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.infraestructure.Repositories
{
    public class FloorRepository : BaseRepository<Floor>, IFloorRepository
    {
        private readonly HotelContext context;

        public FloorRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public override List<Floor> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Removed).ToList();
        }

        public override void Save(Floor entity)
        {
            context.Floors.Add(entity);
            context.SaveChanges();

        }

        public override void Update(Floor entity)
        {
            var floorUpdate = base.GetEntity(entity.FloorId);
            floorUpdate.State = entity.State;
            floorUpdate.RegistrationDate = entity.RegistrationDate;
            floorUpdate.CreationUserId = entity.CreationUserId;
            floorUpdate.Description = entity.Description;

            context.Floors.Update(floorUpdate);
            context.SaveChanges();
        }
    }
}
