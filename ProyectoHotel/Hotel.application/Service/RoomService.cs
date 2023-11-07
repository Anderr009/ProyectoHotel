using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
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
                           ILogger<RoomService> logger) 
        {
            _logger = logger;
            _roomRepository= roomRepository;
        }
        public ServiceResult Add(RoomDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
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
                Room room = new Room()
                {
                    RoomId = dtoRemove.RoomId 
                    ,Removed= dtoRemove.Removed,
                    DeletedUserId =  dtoRemove.userId
                };

                this._roomRepository.Remove(room);

                result.Message = "";
            }catch(Exception ex)
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
