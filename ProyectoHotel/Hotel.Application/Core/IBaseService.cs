

namespace Hotel.application.Core
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Remove(TDtoRemove dtoRemove);
        ServiceResult Add(TDtoAdd dtoAdd);
        ServiceResult Update(TDtoUpdate dtoUpdate);
    }
}
