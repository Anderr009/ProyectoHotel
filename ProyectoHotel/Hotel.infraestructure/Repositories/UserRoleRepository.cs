using System;
using System.Collections.Generic;
using System.Text;
using Hotel.domain.Entities;
using Hotel.domain.Repository;
using Hotel.infraestructure.Core;
using Hotel.infraestructure.Interfaces;
using Hotel.Infraestructure.Context;

namespace Hotel.infraestructure.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(HotelContext context) :base(context) 
        {

        }
    }
}
