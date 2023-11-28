using hotel.api.Models.Modules.Room;
using Hotel.application.Contracts;
using Hotel.application.Core;
using Hotel.application.Dtos.Room;
using Hotel.application.Exceptions;
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
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            this._roomService = roomService;
        }
        // GET: api/<RoomController>
        [HttpGet("GetRooms")]
        public IActionResult Get()
        {

            var result = this._roomService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<RoomController>/5
        [HttpGet("GetRoom")]
        public IActionResult Get(int id)
        {
            var result = this._roomService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<RoomController>
        [HttpPost("SaveRoom")]
        public IActionResult Post([FromBody] RoomDtoAdd roomApp)
        {
            var result = this._roomService.Add(roomApp);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok();
        }

        // PUT api/<RoomController>/5
        [HttpPut("UpdateRoom")]

        public IActionResult Put(int id, [FromBody] RoomDtoUpdate roomUpdate  )
        {
            var result = this._roomService.Update(roomUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok();
        }
        // PUT api/<RoomController>/5
        [HttpPut("RemoveRoom")]

        public IActionResult Put(int id, [FromBody] RoomDtoRemove roomRemove)
        {
            var result = this._roomService.Remove(roomRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok();
        }
        //// DELETE api/<RoomController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
