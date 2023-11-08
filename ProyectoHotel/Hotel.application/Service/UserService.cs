using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.application.Contract;
using Hotel.application.Core;
using Hotel.application.Dtos.User;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hotel.application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(IUserRepository userRepository,
                            ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.userRepository.GetUsersRole();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo los usuarios.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetByID(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.userRepository.GetRole(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }


        public ServiceResult GetByRoleID(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.userRepository.GetUsersRole();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(UserRemoveDto dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                User user = new User()
                {
                    UserID = dtoRemove.UserID,
                    Removed = dtoRemove.Removed,
                    DeletedUserId = dtoRemove.UserDeleted
                };
                this.userRepository.Remove(user);

                result.Message = "El usuario ha sido removido con exito.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo el usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(UserDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                User user = new User() 
                {
                    FullName = dtoAdd.FullName,
                    Mail = dtoAdd.Mail,
                    UserRoleId = dtoAdd.UserRoleId,
                    Clue = dtoAdd.Clue,
                    State = dtoAdd.State,
                    RegistrationDate = dtoAdd.ChangeDate,
                    CreationUserId = dtoAdd.ChangeUser
                };
                this.userRepository.Save(user);

                result.Message = "El usuario ha sido guardado con exito.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error guardando el usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(UserDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                User user = new User()
                {
                    FullName = dtoUpdate.FullName,
                    Mail = dtoUpdate.Mail,
                    UserRoleId = dtoUpdate.UserRoleId,
                    Clue = dtoUpdate.Clue,
                    State = dtoUpdate.State,
                    ModDate = dtoUpdate.ChangeDate,
                    ModUserId = dtoUpdate.ChangeUser
                };
                this.userRepository.Update(user);

                result.Message = "El usuario ha sido actualizado con exito.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error actualizando el usuario.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
