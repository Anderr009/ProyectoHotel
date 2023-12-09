using Hotel.application.Core;
using Hotel.application.Dtos.Client;

namespace Hotel.Web.Interface
{
    public interface IbaseHttp<DtoAdd,DtoRemove,DtoUpdate>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Post(ClientDtoAdd dtoAdd);
        ServiceResult Put(ClientDtoUpdate dtoUpdate);
    }
}
