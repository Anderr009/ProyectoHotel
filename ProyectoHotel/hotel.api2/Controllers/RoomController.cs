using hotel.api.Models.Modules.Room;
using Hotel.domain.Entities;
using Hotel.domain.Repository;
using Hotel.infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }
        // GET: api/<RoomController>
        [HttpGet("GetRooms")]
        public IActionResult Get()
        {

            var rooms = this._roomRepository.GetEntities()
                                            .Select(room => 
                                            new GetRoomModel() 
                                            { 
                                                RoomId = room.RoomId,
                                                Number = room.Number,
                                                Detail =  room.Detail,
                                                Price = room.Price,
                                            });
            return Ok(rooms);
        }

        // GET api/<RoomController>/5
        [HttpGet("GetRoom")]
        public IActionResult Get(int id)
        {
            var room = this._roomRepository.GetEntity(id);
            return Ok(room);
        }

        // POST api/<RoomController>
        [HttpPost("SaveRoom")]
        public IActionResult Post([FromBody] AddRoomModel roomApp)
        {
            this._roomRepository.Save(new Room()
            {
                CreationUserId = roomApp.ChangeUser,
                Price = roomApp.Price,
                State = roomApp.State,
                CategoryId = roomApp.CategoryId,
                FloorId = roomApp.CategoryId,
                RegistrationDate = roomApp.ChangeDate,
                Number = roomApp.Number,
                Detail =  roomApp.Detail,
                RoomStateId = roomApp.RoomStateId,
            });
            return Ok();
        }

        // PUT api/<RoomController>/5
        [HttpPut("UpdateRoom")]

        public IActionResult Put(int id, [FromBody] UpdateRoomModel roomUpdate  )
        {
            this._roomRepository.Update(new Room()
            {
                RoomId = roomUpdate.Id,
                ModUserId = roomUpdate.ChangeUser,
                Price = roomUpdate.Price,
                State = roomUpdate.State,
                CategoryId = roomUpdate.CategoryId,
                FloorId = roomUpdate.CategoryId,
                ModDate = roomUpdate.ChangeDate,
                Number = roomUpdate.Number,
                Detail = roomUpdate.Detail,
                RoomStateId = roomUpdate .RoomStateId,
            });
            return Ok();
        }

        //// DELETE api/<RoomController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
