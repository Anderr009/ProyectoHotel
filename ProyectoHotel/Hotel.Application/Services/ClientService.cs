using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Client;
using Hotel.domain.Entities;
using Hotel.Infrastructure.Interface;

using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.application.Services
{
    public class ClientService : IClientService
    {
       
        private readonly IClientRepository clientRepository;
        private readonly ILogger<ClientService> logger;

        public ClientService(IClientRepository clientRepository,
                             ILogger<ClientService> logger)
        {
            this.clientRepository = clientRepository;
            this.logger = logger;
        }
        public ServiceResult Save(ClientDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Client client = new Client()
                {
                    FullName= dtoAdd.FullName,


                };
                
                result.Message = "$Cliente guardado correctamente";
            } 
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "$Error guardando el cliente";
            }
        }

        public ServiceResult GetAll()
        {
            ServiceResult result= new ServiceResult();
            try
            {
                var clients = this.clientRepository.GetEntities()
                                                    .Where(cl => cl.Removed)
                                                    .Select(cl => new ClientDtoAdd
                                                    {

                                                        ClientId = cl.ClientId,
                                                        FullName = cl.FullName,
                                                        Document = cl.Document,
                                                        DocumentType = cl.DocumentType,
                                                        Mail = cl.Mail,
                                                        State = cl.State,
                                                    }).ToList();
                result.Data= clients;
            }
            catch (Exception ex)
            {
                result.Success= false;
                result.Message = $"Error obteniendo los clientes";
                this.logger.LogError($"{result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
           ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.clientRepository.GetEntity(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el cliente";
                this.logger.LogError($"{result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(ClientDtoRemove dtoRemove)
        {
            ServiceResult result= new ServiceResult();

            return result;

        }

        public ServiceResult Update(ClientDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Client client = new Client()
                {
                    ClientId = dtoUpdate.ClientId,
                    ModDate = dtoUpdate.ChangeDate,
                    ModUserId = dtoUpdate.ChangeUser,
                    FullName = dtoUpdate.FullName,
                    Document = dtoUpdate.Document,
                    DocumentType = dtoUpdate.DocumentType,
                    Mail = dtoUpdate.Mail,
                    State = dtoUpdate.State,
                };
                this.clientRepository.Update(client);
                result.Message = "Cliente actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "$Error actualizando el cliente.";
                this.logger.LogError("", ex.ToString());
            }
            return result;
        
        }
    }
}
