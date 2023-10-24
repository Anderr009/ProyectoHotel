using Hotel.api.Models.Modules.RolUser;
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
        private readonly IRolUserRepository RolUserRepository;

        public RolUserController(IRolUserRepository RolUserRepository)
        {
            this.RolUserRepository = RolUserRepository;
        }

        [HttpGet("GetRolUsers")]
        public IActionResult Get()
        {
            var RolUsers = this.RolUserRepository.GetEntities().Select(ru => new RolUserGetAllModel()
            {
                ChangeUser = ru.CreationUserId,
                ChanageDate = ru.RegistrationDate,
                State = ru.State,
                Description = ru.Description,
                UserRoleId = ru.UserRoleId
            }).ToList();

            return Ok(RolUsers);
        }

        [HttpGet("GetRolUser")]
        public IActionResult GetRolUser(int id)
        {
            var RolUser = this.RolUserRepository.GetEntity(id);
            return Ok(RolUser);
        }

        [HttpPost("SaveRolUser")]
        public IActionResult Post([FromBody] RolUserAddModel RolUserAdd)
        {
            RolUser roluser = new RolUser()
            {
                CreationUserId = RolUserAdd.ChangeUser,
                RegistrationDate = RolUserAdd.ChanageDate,
                State = RolUserAdd.State,
                Description = RolUserAdd.Description
            };
            this.RolUserRepository.Save(roluser);
            return Ok();
        }

        [HttpPut("UpdateRolUser")]
        public IActionResult Put([FromBody] RolUserUpdateModel roluserUpdate)
        {
            RolUser roluser = new RolUser()
            {
                CreationUserId = roluserUpdate.ChangeUser,
                RegistrationDate = roluserUpdate.ChanageDate,
                State = roluserUpdate.State,
                Description = roluserUpdate.Description,
                UserRoleId = roluserUpdate.UserRoleId
            };
            this.RolUserRepository.Update(roluser);

            return Ok();
        }
    }
}