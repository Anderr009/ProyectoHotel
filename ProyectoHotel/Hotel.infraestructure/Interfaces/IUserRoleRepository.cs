using System;
using System.Collections.Generic;
using System.Text;
using Hotel.domain.Entities;
using Hotel.domain.Repository;

namespace Hotel.infraestructure.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>        
    {
    }
}
