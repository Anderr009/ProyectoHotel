using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Floor;
using Hotel.application.Dtos.Reception;
using Hotel.application.Response;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.application.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository FloorRepository;
        private readonly ILogger<FloorService> logger;
        private readonly IConfiguration configuration;

        public FloorService(IFloorRepository roluserRepository,
                                ILogger<FloorService> logger,
                                IConfiguration configuration)
        {
            this.FloorRepository = roluserRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var floors = this.FloorRepository.GetEntities().Where(x=>x.Removed == false).Select(fl => new FloorDtoGetAll()
                {
                    FloorId = fl.FloorId,
                    State = fl.State,
                    RegistrationDate = fl.RegistrationDate,
                    CreationUserId = fl.CreationUserId,
                    ModDate = fl.ModDate,
                    ModUserId = fl.ModUserId,
                    DeletedUserId = fl.DeletedUserId,
                    DateDeleted =  fl.DateDeleted,
                    Removed = fl.Removed
                }); ;
                result.Data = floors;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorFloor:GetErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var floor = this.FloorRepository.GetEntity(Id);
                FloorDtoGetAll floorModel = new FloorDtoGetAll()
                {
                   FloorId = floor.FloorId,
                   State = floor.State,
                   RegistrationDate = floor.RegistrationDate,
                   CreationUserId = floor.CreationUserId,
                   ModDate = floor.ModDate,
                   ModUserId = floor.ModUserId,
                   DeletedUserId = floor.DeletedUserId,
                   DateDeleted = floor.DateDeleted,
                   Removed = floor.Removed
                };
                result.Data = floorModel;
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["Errorfloor:GetByIdErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(FloorDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Floor floor = new Floor()
                {
                    FloorId = dtoRemove.FloorId,
                    Removed = dtoRemove.Removed,
                    DateDeleted = dtoRemove.ChangeDate,
                    DeletedUserId = dtoRemove.ChangeUser
                };

                this.FloorRepository.Remove(floor);

                result.Message = this.configuration["MensajesFloorSuccess:RemoveSuccessMessage"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorFloor:RemoveErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(FloorDtoAdd dtoAdd)
        {
            FloorResponse result = new FloorResponse();
            try
            {

                //Validaciones

               

                Floor floor = new Floor()
                {
                    //FloorId = null,
                    State = dtoAdd.State,
                    RegistrationDate = dtoAdd.RegistrationDate,
                    CreationUserId = dtoAdd.CreationUserId,
                    ModDate = dtoAdd.ModDate,
                    ModUserId = dtoAdd.ModUserId,
                    DeletedUserId = dtoAdd.DeletedUserId,
                    DateDeleted = dtoAdd.DateDeleted,
                    Removed = dtoAdd.Removed

                };

                this.FloorRepository.Save(floor);

                result.Message = this.configuration["MensajesFloorSuccessFloor:AddSuccessMessage"];
                result.FloorId = floor.FloorId;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorFloor:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(FloorDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                //Validaciones

                if (dtoUpdate.FloorId <= 0)
                {
                    result.Message = this.configuration["MensajeValidacionesFloor:FloorValorFloor"];
                    result.Success = false;
                    return result;
                }

                Floor floor = new Floor()
                {
                    FloorId = dtoUpdate.FloorId,
                    State = dtoUpdate.State,
                    RegistrationDate = dtoUpdate.RegistrationDate,
                    CreationUserId = dtoUpdate.CreationUserId,
                    ModDate = dtoUpdate.ModDate,
                    ModUserId = dtoUpdate.ModUserId,
                    DeletedUserId = dtoUpdate.DeletedUserId,
                    DateDeleted = dtoUpdate.DateDeleted,
                    Removed = dtoUpdate.Removed
                };

                this.FloorRepository.Update(floor);

                result.Data = this.configuration["MensajesFLoorSuccess:UpdateSuccessMessage"];
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["ErrorFloor:UpdateErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}

