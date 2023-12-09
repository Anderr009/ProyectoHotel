using Hotel.application.Core;
using Hotel.application.Dtos.Client;
using Hotel.Web.Interface;
using Hotel.Web.Models.Response;
using Newtonsoft.Json;

namespace Hotel.Web.Service
{
    public class ClientHttpService : IClientHttpService
    {
        private readonly ILogger<ClientHttpService> _logger;
        readonly IBaseRequestHttpClient _httpClient;

        public ClientHttpService(IBaseRequestHttpClient httpClient
            , ILogger<ClientHttpService> logger, IConfiguration configuration)
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
                string apiResponse = this._httpClient.Get(Configuration["Urls:Client:Get"]);
                ClientListResponse clientList = JsonConvert.DeserializeObject<ClientListResponse>(apiResponse);
                result.Data = clientList.data;
                result.Success = clientList.success;
                result.Message = "Extraccion exitosa";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las habitaciones";
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            var url = Configuration["Urls:Client:GetById"];
            try
            {
                string apiResponse = this._httpClient.Get(url + $"?id={id}");
                ClientListResponse clientList = JsonConvert.DeserializeObject<ClientListResponse>(apiResponse);
                result.Data = clientList.data;
                result.Success = clientList.success;
                result.Message = "Extraccion exitosa";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las habitaciones";
            }

            return result;
        }

        public ServiceResult Post(ClientDtoAdd dtoAdd)
        {
            dtoAdd.date = DateTime.Now;
            dtoAdd.ClientId = 1;
            ServiceResult result = new ServiceResult();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(dtoAdd), System.Text.Encoding.UTF8, "application/json");
                string apiResponse = this._httpClient.Post(Configuration["Urls:Client:Post"], content);
                BaseResponse clientList = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                result.Data = clientList;
                result.Success = clientList.success;
                result.Message = "Insertado exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al insertar la habitacion";
            }
            return result;
        }

        public ServiceResult Put(ClientDtoUpdate dtoUpdate)
        {
            dtoUpdate.date = DateTime.Now;
            dtoUpdate.IdClient = 1;

            ServiceResult result = new ServiceResult();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(dtoUpdate), System.Text.Encoding.UTF8, "application/json");
                string apiResponse = this._httpClient.Put(Configuration["Urls:Client:Post"], content);
                BaseResponse clientList = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                result.Data = clientList;
                result.Success = clientList.success;
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
