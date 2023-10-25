using Hotel.domain.Entities;
using Hotel.infraestructure.Core;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly HotelContext context;

        public UserRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public List<User> GetUsersByRole(int UserRoleId)
        {
            return this.context.Users.Where(rl => rl.UserRoleId == UserRoleId && !rl.Removed).ToList();
        }

        public override List<User> GetEntities()
        {
            return base.GetEntities().Where(us => !us.Removed).ToList();
        }

        public override void Save(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();

        }

        public override void Update(User entity)
        {
            var UserUpdate = base.GetEntity(entity.UserID);
            UserUpdate.FullName = entity.FullName;
            UserUpdate.Mail = entity.Mail;
            UserUpdate.UserRoleId = entity.UserRoleId;
            UserUpdate.Clue = entity.Clue;
            UserUpdate.State = entity.State;
            UserUpdate.RegistrationDate = entity.RegistrationDate;
            UserUpdate.CreationUserId = entity.CreationUserId;

            context.Users.Update(UserUpdate);
            context.SaveChanges();
        }
    }
}
