using Hotel.api.Models.Modules.Floor;
using Hotel.domain.Core;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorRepository FloorRepository;

        public FloorController(IFloorRepository FloorRepository)
        {
            this.FloorRepository = FloorRepository;
        }

        [HttpGet("GetFloors")]
        public IActionResult Get()
        {
            var Floors = this.FloorRepository.GetEntities().Select(fl => new FloorGetAllModel()
            {
                ChangeUser = fl.CreationUserId,
                ChanageDate = fl.RegistrationDate,
                State = fl.State,
                Description = fl.Description,
                FloorId= fl.FloorId
                
            }).ToList();

            return Ok(Floors);
        }

        [HttpGet("GetFloor")]
        public IActionResult GetFloor(int id)
        {
            var Floor = this.FloorRepository.GetEntity(id);
            return Ok(Floor);
        }

        [HttpPost("SaveFloor")]
        public IActionResult Post([FromBody] FloorAddModel floorAdd)
        {
            Floor floor = new Floor()
            {
                CreationUserId = floorAdd.ChangeUser,
                RegistrationDate = floorAdd.ChanageDate,
                State = floorAdd.State,
                Description = floorAdd.Description
            };
            this.FloorRepository.Save(floor);

            return Ok();
        }

        [HttpPut("UpdateFloor")]
        public IActionResult Put([FromBody] FloorUpdateModel floorUpdate)
        {
            Floor floor = new Floor()
            {
                CreationUserId = floorUpdate.ChangeUser,
                RegistrationDate = floorUpdate.ChanageDate,
                State = floorUpdate.State,
                Description = floorUpdate.Description,
                FloorId = floorUpdate.FloorId
            };
            this.FloorRepository.Update(floor);

            return Ok();
        }
    }
}