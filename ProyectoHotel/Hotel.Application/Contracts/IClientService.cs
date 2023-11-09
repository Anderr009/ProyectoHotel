using Hotel.application.Core;
using Hotel.application.Dtos.Client;

namespace Hotel.application.Contracts
{
    public interface IClientService : IBaseService<ClientDtoAdd, ClientDtoUpdate, ClientDtoRemove>
    {
        
    }
}
