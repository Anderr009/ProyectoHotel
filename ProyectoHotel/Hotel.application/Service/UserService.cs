using System;
using Hotel.application.Contract;
using Hotel.application.Core;
using Hotel.application.Dtos.User;
using Hotel.application.Exceptions;
using Hotel.domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hotel.application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;
        private readonly IConfiguration configuration;

        public UserService(IUserRepository userRepository,
                            ILogger<UserService> logger, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            this.configuration = configuration;
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
                if (string.IsNullOrEmpty(dtoAdd.FullName))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:FullNameRequired"]);

                if (dtoAdd.FullName.Length > 50)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:FullNameLength"]);

                if (string.IsNullOrEmpty(dtoAdd.Mail))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:MailRequired"]);

                if (dtoAdd.Mail.Length > 50)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:MailLenght"]);

                if (dtoAdd.UserRoleId == 0)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:UserRoleIdRequired"]);

                if (dtoAdd.UserRoleId < 0)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:UserRoleIdPositive"]);

                if (!int.TryParse(dtoAdd.UserRoleId.ToString(), out int userRoleId))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:UserRoleIdIsInt"]);

                if (string.IsNullOrEmpty(dtoAdd.Clue))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:ClueRequired"]);

                if (dtoAdd.Clue.Length > 50)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:ClueLenght"]);

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
            catch (UserServiceExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}", uex.ToString());
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
                if (string.IsNullOrEmpty(dtoUpdate.FullName))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:FullNameRequired"]);

                if (dtoUpdate.FullName.Length > 50)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:FullNameLength"]);

                if (string.IsNullOrEmpty(dtoUpdate.Mail))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:MailRequired"]);

                if (dtoUpdate.Mail.Length > 50)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:MailLenght"]);

                if (dtoUpdate.UserRoleId == 0)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:UserRoleIdRequired"]);

                if (dtoUpdate.UserRoleId < 0)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:UserRoleIdPositive"]);

                if (!int.TryParse(dtoUpdate.UserRoleId.ToString(), out int userRoleId))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:UserRoleIdIsInt"]);

                if (string.IsNullOrEmpty(dtoUpdate.Clue))
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:ClueRequired"]);

                if (dtoUpdate.Clue.Length > 50)
                    throw new UserServiceExceptions(this.configuration["ValidationMessages:ClueLenght"]);

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
            catch (UserServiceExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"{result.Message}", uex.ToString());
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
