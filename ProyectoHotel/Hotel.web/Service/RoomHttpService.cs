using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using Hotel.web.Interface;
using Hotel.web.Models.Response;
using Newtonsoft.Json;

namespace Hotel.web.Service
{
    public class RoomHttpService : IRoomHttpService
    {
        private readonly ILogger<RoomHttpService> _logger;
        readonly IBaseRequestHttpClient _httpClient;

        public RoomHttpService(IBaseRequestHttpClient httpClient
            ,ILogger<RoomHttpService> logger,IConfiguration configuration)
        {
           this._httpClient = httpClient;
           Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                string apiResponse = this._httpClient.Get(Configuration["Urls:Room:Get"]);
                RoomListResponse roomList = JsonConvert.DeserializeObject<RoomListResponse>(apiResponse);
                result.Data = roomList.data;
                result.Success = roomList.success;
                result.Message = "Extraccion exitosa";
            }
            catch (Exception ex) {
                result.Success = false;
                result.Message = "Error al obtener las habitaciones";
            }
            
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            var url = Configuration["Urls:Room:GetById"];
            try
            {
                string apiResponse = this._httpClient.Get(url + $"?id={id}");
                RoomDetailResponse roomList = JsonConvert.DeserializeObject<RoomDetailResponse>(apiResponse);
                result.Data = roomList.data;
                result.Success = roomList.success;
                result.Message = "Extraccion exitosa";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las habitaciones";
            }

            return result;
        }

        public ServiceResult Post(RoomDtoAdd dtoAdd)
        {
            dtoAdd.date = DateTime.Now;
            dtoAdd.userId = 1;
            ServiceResult result = new ServiceResult();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(dtoAdd), System.Text.Encoding.UTF8, "application/json");
                string apiResponse = this._httpClient.Post(Configuration["Urls:Room:Post"],content);
                BaseResponse roomList = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                result.Data = roomList;
                result.Success = roomList.success;
                result.Message = "Insertado exitosamente";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al insertar la habitacion";
            }
            return result;
        }

        public ServiceResult Put(RoomDtoUpdate dtoUpdate)
        {
            dtoUpdate.date = DateTime.Now;
            dtoUpdate.userId = 1;

            ServiceResult result = new ServiceResult();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(dtoUpdate), System.Text.Encoding.UTF8, "application/json");
                string apiResponse = this._httpClient.Put(Configuration["Urls:Room:Post"], content);
                BaseResponse roomList = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                result.Data = roomList;
                result.Success = roomList.success;
                result.Message = "Actualizado exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la habitacion";
            }
            return result;
        }
    }
}
