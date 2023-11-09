using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Floor;
using Hotel.application.Dtos.Reception;
using Hotel.application.Dtos.RoUser;
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
    public class RolUserService
    {
            private readonly IRolUserRepository RolUserRepository;
            private readonly ILogger<RolUserService> logger;
            private readonly IConfiguration configuration;

            public RolUserService(IRolUserRepository roluserRepository,
                                    ILogger<RolUserService> logger,
                                    IConfiguration configuration)
            {
                this.RolUserRepository = roluserRepository;
                this.logger = logger;
                this.configuration = configuration;
            }

            public ServiceResult GetAll()
            {
                ServiceResult result = new ServiceResult();

                try
                {
                    var floors = this.RolUserRepository.GetEntities().Select(ru => new RolUserDtoGetAll()
                    {
                        UserRoleId = ru.UserRoleId,
                        State = ru.State,
                        RegistrationDate = ru.RegistrationDate,
                        CreationUserId = ru.CreationUserId,
                        ModDate = ru.ModDate,
                        ModUserId = ru.ModUserId,
                        DeletedUserId = ru.DeletedUserId,
                        DateDeleted = ru.DateDeleted,
                        Removed = ru.Removed
                    }); ;
                    result.Data = floors;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this.configuration["ErrorRolUser:GetErrorMessage"];
                    this.logger.LogError(result.Message, ex.ToString());
                }
                return result;
            }

            public ServiceResult GetById(int Id)
            {
                ServiceResult result = new ServiceResult();

                try
                {
                    var RolUser = this.RolUserRepository.GetEntity(Id);
                    RolUserDtoGetAll RolUserModel = new RolUserDtoGetAll()
                    {
                        UserRoleId = RolUser.UserRoleId,
                        State = RolUser.State,
                        RegistrationDate = RolUser.RegistrationDate,
                        CreationUserId = RolUser.CreationUserId,
                        ModDate = RolUser.ModDate,
                        ModUserId = RolUser.ModUserId,
                        DeletedUserId = RolUser.DeletedUserId,
                        DateDeleted = RolUser.DateDeleted,
                        Removed = RolUser.Removed
                    };
                    result.Data = RolUserModel;
                }
                catch (Exception ex)
                {
                    result.Message = this.configuration["ErrorRolUser:GetByIdErrorMessage"];
                    this.logger.LogError(result.Message, ex.ToString());
                }

                return result;
            }

            public ServiceResult Remove(RolUserDtoRemove dtoRemove)
            {
                ServiceResult result = new ServiceResult();

                try
                {
                    RolUser roluser = new RolUser()
                    {
                        UserRoleId = dtoRemove.UserRoleId,
                        Removed = dtoRemove.Removed,
                        DateDeleted = dtoRemove.ChangeDate,
                        DeletedUserId = dtoRemove.ChangeUser
                    };

                    this.RolUserRepository.Remove(roluser);

                    result.Message = this.configuration["MensajesRolUserSuccess:RemoveSuccessMessage"];
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this.configuration["ErrorRolUser:RemoveErrorMessage"];
                    this.logger.LogError(result.Message, ex.ToString());
                }
                return result;
            }

            public ServiceResult Save(RolUserDtoAdd dtoAdd)
            {
                RolUserResponse result = new RolUserResponse();
                try
                {

                    //Validaciones

                    if (dtoAdd.UserRoleId <= 0)
                    {
                        result.Message = this.configuration["MensajeValidacionesRolUser:RolUserValorUserRole"];
                        result.Success = false;
                        return result;
                    }


                    if (dtoAdd.RegistrationDate >= dtoAdd.RegistrationDate)
                    {
                        result.Message = this.configuration["MensajeValidaciones:RolUserValorRegistrationDate"];
                        result.Success = false;
                        return result;
                    }

                    RolUser rolUser = new RolUser()
                    {
                        UserRoleId = dtoAdd.UserRoleId,
                        State = dtoAdd.State,
                        RegistrationDate = dtoAdd.RegistrationDate,
                        CreationUserId = dtoAdd.CreationUserId,
                        ModDate = dtoAdd.ModDate,
                        ModUserId = dtoAdd.ModUserId,
                        DeletedUserId = dtoAdd.DeletedUserId,
                        DateDeleted = dtoAdd.DateDeleted,
                        Removed = dtoAdd.Removed

                    };

                    this.RolUserRepository.Save(rolUser);

                    result.Message = this.configuration["MensajesRolUserSuccess:AddSuccessMessage"];
                    result.RolUserId = rolUser.UserRoleId;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this.configuration["ErrorRolUser:AddErrorMessage"];
                    this.logger.LogError(result.Message, ex.ToString());
                }
                return result;
            }

            public ServiceResult Update(RolUserDtoUpdate dtoUpdate)
            {
                ServiceResult result = new ServiceResult();

                try
                {

                    //Validaciones

                    if (dtoUpdate.UserRoleId <= 0)
                    {
                        result.Message = this.configuration["MensajeValidacionesRolUser:RolUserValorUserRole"];
                        result.Success = false;
                        return result;
                    }

                    if (dtoUpdate.RegistrationDate >= dtoUpdate.RegistrationDate)
                    {
                        result.Message = this.configuration["MensajeValidacionesRolUser:FloorValorRegistrationDate"];
                        result.Success = false;
                        return result;
                    }

                    RolUser rolUser = new RolUser()
                    {
                        UserRoleId = dtoUpdate.UserRoleId,
                        State = dtoUpdate.State,
                        RegistrationDate = dtoUpdate.RegistrationDate,
                        CreationUserId = dtoUpdate.CreationUserId,
                        ModDate = dtoUpdate.ModDate,
                        ModUserId = dtoUpdate.ModUserId,
                        DeletedUserId = dtoUpdate.DeletedUserId,
                        DateDeleted = dtoUpdate.DateDeleted,
                        Removed = dtoUpdate.Removed
                    };

                    this.RolUserRepository.Update(rolUser);

                    result.Data = this.configuration["MensajesRolUserSuccess:UpdateSuccessMessage"];
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this.configuration["ErrorRolUser:UpdateErrorMessage"];
                    this.logger.LogError(result.Message, ex.ToString());
                }
                return result;
            }
        }
    }
