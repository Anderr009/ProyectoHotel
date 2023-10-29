using Hotel.application.Core;
using Hotel.application.Dtos.Reception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Contracts
{
    public interface IReceptionService : IBaseService<ReceptionDtoAdd, ReceptionDtoUpdate, ReceptionDtoRemove>
    {
    }
}
