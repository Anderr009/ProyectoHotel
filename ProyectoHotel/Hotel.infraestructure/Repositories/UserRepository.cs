using Hotel.domain.Entities;
using Hotel.infraestructure.Core;
using Hotel.infraestructure.Models;
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
            User user = base.GetEntity(entity.UserID);
            user.FullName = entity.FullName;
            user.Mail = entity.Mail;
            user.UserRoleId = entity.UserRoleId;
            user.Clue = entity.Clue;
            user.State = entity.State;
            user.ModDate = entity.ModDate;
            user.ModUserId = entity.ModUserId;

            this.context.Users.Update(user);
            this.context.SaveChanges();
        }

        public override void Remove(User entity)
        {
            User user = base.GetEntity(entity.UserID);

            user.UserID = entity.UserID;
            user.Removed = entity.Removed;
            user.DateDeleted = entity.DateDeleted;
            user.DeletedUserId = entity.DeletedUserId;

            context.Users.Update(user);
            context.SaveChanges();
        }

        public List<User_RoleModel> GetUsersRole()
        {
            var users = (from us in this.GetEntities()
                         join role in this.context.Roles on us.UserRoleId equals role.UserRoleId
                         where !us.Removed
                         select new User_RoleModel
                         {
                             UserID = us.UserID,
                             UserRoleId = us.UserRoleId,
                             Clue = us.Clue,
                             Role = role.Description,
                             CreationDate = us.RegistrationDate
                         }).ToList();
            return users;
        }

        public User_RoleModel GetRole(int roleId)
        {
            return this.GetUsersRole().SingleOrDefault(us => us.UserID == roleId);
        }

        
    }
}
