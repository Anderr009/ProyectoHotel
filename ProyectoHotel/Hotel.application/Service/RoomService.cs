using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using Hotel.application.Exceptions;
using Hotel.Application.Extentions;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Hotel.application.Service
{
    public class RoomService : IRoomService
    {
        private readonly ILogger _logger;   
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository,
                           ILogger<RoomService> logger,
                           IConfiguration configuration) 
        {
            _logger = logger;
            _roomRepository= roomRepository;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public ServiceResult Add(RoomDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = dtoAdd.IsRoomValid(Configuration);

                if (!result.Success)
                {
                    return result;
                }
                Room room = new Room()
                {
                    RoomId = dtoAdd.userId,
                    Detail = dtoAdd.Detail,
                    Price = dtoAdd.Price,
                    CategoryId = dtoAdd.CategoryId,
                    CreationUserId = dtoAdd.userId,
                    RegistrationDate = dtoAdd.date,
                    FloorId = dtoAdd.FloorId,
                    Number = dtoAdd.Number,
                };
                this._roomRepository.Save(room);
                result.Message = "Habitacion guardada correctamente.";
            }catch(Exception ex)
            {
                result.Success = false;
                result.Message = "$Error guardando la habitacion.";
                this._logger.LogError("", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rooms = _roomRepository.GetEntities()
                                            .Where(room => !room.Removed)
                                            .Select(co => new RoomDtoGet() {
                                                RoomId = co.RoomId,
                                                Number = co.Number,
                                                Detail = co.Detail,
                                                Price = co.Price,
                                                RoomStateId = co.RoomStateId,
                                                FloorId = co.FloorId,
                                                CategoryId = co.CategoryId,
                                            })
                                            .ToList();
                result.Data = rooms;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "$Error obteniendo las habitaciones.";
                this._logger.LogError("", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this._roomRepository.GetEntity(id);
            }catch (Exception ex)
            {
                result.Success = false;
                result.Message = "$Error obteniendo la habitacion.";
                this._logger.LogError("", ex.ToString());
            }
            return result;
        }

   
        public ServiceResult Remove(RoomDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                //if (!dtoRemove.Removed.HasValue)
                //{
                //    throw new RoomServiceException(this.Configuration["MensajeValidaciones:RoomRemoved"]);
                //}
                Room room = new Room()
                {
                    RoomId = dtoRemove.RoomId 
                    ,Removed= dtoRemove.Removed,
                    DeletedUserId =  dtoRemove.userId
                };

                this._roomRepository.Remove(room);

                result.Message = "";
            }
            catch(RoomServiceException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this._logger.LogError("", ex.Message.ToString());
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "$Error removiendo la habitacion.";
                this._logger.LogError("", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(RoomDtoUpdate dtoUpdate)
        {
            ServiceResult result= new ServiceResult();
            try
            {
                result = dtoUpdate.IsRoomValid(Configuration);

                if (!result.Success)
                {
                    return result;
                }
                Room room = new Room()
                {
                    RoomId = dtoUpdate.userId,
                    Detail = dtoUpdate.Detail,
                    Price = dtoUpdate.Price,
                    CategoryId = dtoUpdate.CategoryId,
                    CreationUserId = dtoUpdate.userId,
                    RegistrationDate = dtoUpdate.date,
                    FloorId = dtoUpdate.FloorId,
                    Number = dtoUpdate.Number,
                    ModDate = dtoUpdate.date,
                    ModUserId = dtoUpdate.userId
                };
                this._roomRepository.Update(room);
                result.Message = "Habitacion actualizada correctamente.";
            }catch(Exception ex)
            {

                result.Success = false;
                result.Message = "$Error actualizando la habitacion.";
                this._logger.LogError("", ex.ToString());
            }
            return result;
        }
    }
}
