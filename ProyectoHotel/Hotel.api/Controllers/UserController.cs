using Hotel.domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Hotel.api.Models.Modules.User;
using Hotel.application.Contract;
using Hotel.application.Dtos.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet("GetUserByRole")]
        public IActionResult GetUserByRoles(int RoleId)
        {
            var result = this.userService.GetByRoleID(RoleId);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET: api/<UserController>
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            var result = this.userService.GetAll();

            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("GetUser")]
        public IActionResult GetUser(int UserId) 
        {
            var result = this.userService.GetByID(UserId);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    

        // POST api/<UserController>
        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UserDtoAdd userAdd)
        {
            var result = this.userService.Save(userAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    
        

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UserDtoUpdate userUpdate)
        {
            var result = this.userService.Update(userUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
