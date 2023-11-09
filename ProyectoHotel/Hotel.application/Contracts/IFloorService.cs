using Hotel.application.Core;
using Hotel.application.Dtos.Floor;
using Hotel.application.Dtos.Reception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Contracts
{
    public interface IFloorService : IBaseServices<FloorDtoAdd, FloorDtoUpdate, FloorDtoRemove>
    {
    }
}
