using Hotel.api.Models.Modules.Floor;
using Hotel.application.Contracts;
using Hotel.application.Dtos.Floor;
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
        private readonly IFloorService FloorService;

        public FloorController(IFloorService FloorService)
        {
            this.FloorService = FloorService;
        }

        [HttpGet("GetFloors")]
        public IActionResult Get()
        {
            var result = this.FloorService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetFloor")]
        public IActionResult GetFloor(int id)
        {
            var result = this.FloorService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveFloor")]
        public IActionResult Post([FromBody] FloorAddModel floorAdd)
        {
            var result = this.FloorService.Save(floorAdd);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateFloor")]
        public IActionResult Put([FromBody] FloorUpdateModel floorUpdate)
        {
            var result = this.FloorService.Update(floorUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveFloor")]
        public IActionResult Remove([FromBody] FloorDtoRemove floorDtoRemove)
        {
            var result = this.FloorService.Remove(floorDtoRemove);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }
    }
}