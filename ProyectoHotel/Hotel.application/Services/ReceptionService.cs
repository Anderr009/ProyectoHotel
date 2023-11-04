using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Reception;
using Hotel.application.Response;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.application.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly IReceptionRepository receptionRepository;
        private readonly ILogger<ReceptionService> logger;
        private readonly IConfiguration configuration;

        public ReceptionService(IReceptionRepository receptionRepository, 
                                ILogger<ReceptionService> logger, 
                                IConfiguration configuration) 
        {
            this.receptionRepository = receptionRepository;
            this.logger = logger;
            this.configuration = configuration;
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
                result.Message = this.configuration["ErrorRecepcion:GetErrorMessage"];
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
                result.Message = this.configuration["ErrorRecepcion:GetByIdErrorMessage"];
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

                result.Message = this.configuration["MensajesRecepcionSuccess:RemoveSuccessMessage"];
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = this.configuration["ErrorRecepcion:RemoveErrorMessage"];
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

                //Validaciones

                if (dtoAdd.ClientId <= 0) 
                {
                    result.Message = this.configuration["MensajeValidaciones:RecepcionValorCliente"];
                    result.Success = false;
                    return result;
                }

                if (dtoAdd.RoomId <= 0)
                {
                    result.Message = this.configuration["MensajeValidaciones:RcepcionValorRoom"];
                    result.Success = false;
                    return result;
                }

                if (dtoAdd.EntryDate >= dtoAdd.DepartureDate)
                {
                    result.Message = this.configuration["MensajeValidaciones:RecepcionFechaSalida"];
                    result.Success = false;
                    return result;
                }

                if (dtoAdd.StartingPrice < 0 || dtoAdd.Advancement < 0 || dtoAdd.RemainingPrice < 0 || dtoAdd.TotalPaid < 0 || dtoAdd.CostPenalty < 0)
                {
                    result.Message = this.configuration["MensajeValidaciones:RerepcionPrecioNegativo"];
                    result.Success = false;
                    return result;
                }

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

                result.Message = this.configuration["MensajesRecepcionSuccess:AddSuccessMessage"];
                result.ReceptionId = reception.ReceptionId;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorRecepcion:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(ReceptionDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                //Validaciones

                if (dtoUpdate.ClientId <= 0)
                {
                    result.Message = this.configuration["MensajeValidaciones:RecepcionValorCliente"];
                    result.Success = false;
                    return result;
                }

                if (dtoUpdate.RoomId <= 0)
                {
                    result.Message = this.configuration["MensajeValidaciones:RcepcionValorRoom"];
                    result.Success = false;
                    return result;
                }

                if (dtoUpdate.EntryDate >= dtoUpdate.DepartureDate)
                {
                    result.Message = this.configuration["MensajeValidaciones:RecepcionFechaSalida"];
                    result.Success = false;
                    return result;
                }

                if (dtoUpdate.StartingPrice < 0 || dtoUpdate.Advancement < 0 || dtoUpdate.RemainingPrice < 0 || dtoUpdate.TotalPaid < 0 || dtoUpdate.CostPenalty < 0)
                {
                    result.Message = this.configuration["MensajeValidaciones:RerepcionPrecioNegativo"];
                    result.Success = false;
                    return result;
                }

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

                result.Data = this.configuration["MensajesRecepcionSuccess:UpdateSuccessMessage"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorRecepcion:UpdateErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
