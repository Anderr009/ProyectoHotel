using System;
using System.Collections.Generic;
using System.Text;
using Hotel.domain.Entities;
using Hotel.domain.Repository;
using Hotel.infraestructure.Models;

namespace Hotel.Infraestructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User_RoleModel> GetUsersRole();
        User_RoleModel GetRole(int roleId);
    }
}
