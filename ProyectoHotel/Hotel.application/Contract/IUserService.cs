using System;
using System.Collections.Generic;
using System.Text;
using Hotel.application.Core;
using Hotel.application.Dtos.User;

namespace Hotel.application.Contract
{
    public interface IUserService : IBaseService<UserDtoAdd, UserDtoUpdate, UserRemoveDto>
    {
        ServiceResult GetByRoleID(int id);
    }
}
