using Hotel.api.Models.Modules.RolUser;
using Hotel.application.Contracts;
using Hotel.application.Dtos.RoUser;
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
    public class RolUserController : ControllerBase
    {
        private readonly IRolUserService RolUserService;

        public RolUserController(IRolUserService RolUserService)
        {
            this.RolUserService = RolUserService;
        }

        [HttpGet("GetRolUsers")]
        public IActionResult Get()
        {
            var result = this.RolUserService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetRolUser")]
        public IActionResult GetRolUser(int id)
        {
            var result = this.RolUserService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveRolUser")]
        public IActionResult Post([FromBody] RolUserAddModel rolUserAdd)
        {
            var result = this.RolUserService.Save(rolUserAdd);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateRolUser")]
        public IActionResult Put([FromBody] RolUserUpdateModel roluserUpdate)
        {
            var result = this.RolUserService.Update(roluserUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveReception")]
        public IActionResult Remove([FromBody] RolUserDtoRemove roluserDtoRemove)
        {
            var result = this.RolUserService.Remove(roluserDtoRemove);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }
    }
}