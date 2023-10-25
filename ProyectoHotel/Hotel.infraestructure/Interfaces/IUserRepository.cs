using System;
using System.Collections.Generic;
using System.Text;
using Hotel.domain.Entities;
using Hotel.domain.Repository;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> GetUsersByRole(int userRoleId);
    }
}
