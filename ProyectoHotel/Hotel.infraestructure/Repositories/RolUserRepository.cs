using Hotel.domain.Entities;
using Hotel.infraestructure.Context;
using Hotel.infraestructure.Core;
using Hotel.infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.infraestructure.Repositories
{
    public class RolUserRepository : BaseRepository<RolUser>, IRolUserRepository
    {
        private readonly HotelContext context;

        public RolUserRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public override List<RolUser> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Removed).ToList();
        }

        public override void Save(RolUser entity)
        {
            context.UserRoles.Add(entity);
            context.SaveChanges();

        }

        public override void Update(RolUser entity)
        {
            var roluserUpdate = base.GetEntity(entity.UserRoleId);
            roluserUpdate.State = entity.State;
            roluserUpdate.RegistrationDate = entity.RegistrationDate;
            roluserUpdate.CreationUserId = entity.CreationUserId;
            roluserUpdate.Description = entity.Description;

            context.UserRoles.Update(roluserUpdate);
            context.SaveChanges();
        }
    }
}
