using Hotel.application.Core;
using Hotel.application.Dtos.Floor;
using Hotel.application.Dtos.Reception;
using Hotel.application.Dtos.RoUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Contracts
{
    public interface IRolUserService : IBaseServices<RolUserDtoAdd, RolUserDtoUpdate, RolUserDtoRemove>
    {
    }
}
