using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Reception;
using Hotel.application.Response;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.application.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly IReceptionRepository receptionRepository;
        private readonly ILogger<ReceptionService> logger;

        public ReceptionService(IReceptionRepository receptionRepository, ILogger<ReceptionService> logger) 
        {
            this.receptionRepository = receptionRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var receptions = this.receptionRepository.GetEntities().Select(rc => new ReceptionDtoGetAll()
                {
                    RegistrationDate = rc.RegistrationDate,
                    State = rc.State,
                    Observation = rc.Observation,
                    CostPenalty = rc.CostPenalty,
                    TotalPaid = rc.TotalPaid,
                    RemainingPrice = rc.RemainingPrice,
                    Advancement = rc.Advancement,
                    StartingPrice = rc.StartingPrice,
                    ConfirmationDepartureDate = rc.ConfirmationDepartureDate,
                    DepartureDate = rc.DepartureDate,
                    EntryDate = rc.EntryDate,
                    RoomId = rc.RoomId,
                    ClientId = rc.ClientId,
                    ReceptionId = rc.ReceptionId
                });
                result.Data = receptions;
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo las recepciones.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult() ;

            try 
            {
                var reception = this.receptionRepository.GetEntity(Id);
                ReceptionDtoGetAll receptionModel = new ReceptionDtoGetAll()
                {
                    RegistrationDate = reception.RegistrationDate,
                    State = reception.State,
                    Observation = reception.Observation,
                    CostPenalty = reception.CostPenalty,
                    TotalPaid = reception.TotalPaid,
                    RemainingPrice = reception.RemainingPrice,
                    Advancement = reception.Advancement,
                    StartingPrice = reception.StartingPrice,
                    ConfirmationDepartureDate = reception.ConfirmationDepartureDate,
                    DepartureDate = reception.DepartureDate,
                    EntryDate = reception.EntryDate,
                    RoomId = reception.RoomId,
                    ClientId = reception.ClientId,
                    ReceptionId = reception.ReceptionId
                };
                result.Data = receptionModel;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo la recepcion.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(ReceptionDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Reception reception = new Reception()
                {
                    ReceptionId = dtoRemove.ReceptionId,
                    Removed = dtoRemove.Removed,
                    DateDeleted = dtoRemove.ChangeDate,
                    DeletedUserId = dtoRemove.ChangeUser
                };

                this.receptionRepository.Remove(reception);

                result.Message = "La recepcion fue removida";
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = $"Ocurrio un error Removiendo la recepcion.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(ReceptionDtoAdd dtoAdd)
        {
            //ServiceResult result = new ServiceResult();
            ReceptionResponse result = new ReceptionResponse();
            try
            {
                Reception reception = new Reception()
                {
                    CreationUserId = dtoAdd.ChangeUser,
                    RegistrationDate = dtoAdd.ChangeDate,
                    State = dtoAdd.State,
                    Observation = dtoAdd.Observation,
                    CostPenalty = dtoAdd.CostPenalty,
                    TotalPaid = dtoAdd.TotalPaid,
                    RemainingPrice = dtoAdd.RemainingPrice,
                    Advancement = dtoAdd.Advancement,
                    StartingPrice = dtoAdd.StartingPrice,
                    ConfirmationDepartureDate = dtoAdd.ConfirmationDepartureDate,
                    DepartureDate = dtoAdd.DepartureDate,
                    EntryDate = dtoAdd.EntryDate,
                    RoomId = dtoAdd.RoomId,
                    ClientId = dtoAdd.ClientId
                };

                this.receptionRepository.Save(reception);

                result.Message = "La recepcion fue creado correctamente.";
                result.ReceptionId = reception.ReceptionId;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error guardando la recepcion.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(ReceptionDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Reception reception = new Reception()
                {
                    CreationUserId = dtoUpdate.ChangeUser,
                    RegistrationDate = dtoUpdate.ChangeDate,
                    State = dtoUpdate.State,
                    Observation = dtoUpdate.Observation,
                    CostPenalty = dtoUpdate.CostPenalty,
                    TotalPaid = dtoUpdate.TotalPaid,
                    RemainingPrice = dtoUpdate.RemainingPrice,
                    Advancement = dtoUpdate.Advancement,
                    StartingPrice = dtoUpdate.StartingPrice,
                    ConfirmationDepartureDate = dtoUpdate.ConfirmationDepartureDate,
                    DepartureDate = dtoUpdate.DepartureDate,
                    EntryDate = dtoUpdate.EntryDate,
                    RoomId = dtoUpdate.RoomId,
                    ClientId = dtoUpdate.ClientId,
                    ReceptionId = dtoUpdate.ReceptionId
                };

                this.receptionRepository.Update(reception);

                result.Data = "La recepcion fue actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error actualizando la recepcion.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
