using Hotel.domain.Entities;
using Hotel.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Hotel.api.Models.Modules.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetUserByRole")]
        public IActionResult GetUserByRole(int UserRoleId)
        {
            var users = this.userRepository.GetUsersByRole(UserRoleId);
            return Ok(users);
        }

        // GET: api/<UserController>
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            var users = this.userRepository.GetEntities().Select(us => new UserGetAllModel()
            {
                ChangeUser = us.CreationUserId,
                ChanageDate = us.RegistrationDate,
                State = us.State,
                Clue = us.Clue,
                UserRoleId = us.UserRoleId,
                Mail = us.Mail,
                FullName = us.FullName,
                UserId = us.UserID
            }).ToList();
            
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("GetUser")]
        public IActionResult GetUser(int UserId) 
        {
            var user = this.userRepository.GetEntity(UserId);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UserAddModel userAdd)
        {
            User user = new User()
            {
                CreationUserId = userAdd.ChangeUser,
                RegistrationDate = userAdd.ChanageDate,
                State = userAdd.State,
                Clue = userAdd.Clue,
                UserRoleId = userAdd.UserRoleId,
                Mail = userAdd.Mail,
                FullName = userAdd.FullName
            };
            this.userRepository.Save(user);

            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UserUpdateModel userUpdate)
        {
            User user = new User()
            {
                CreationUserId = userUpdate.ChangeUser,
                RegistrationDate = userUpdate.ChanageDate,
                State = userUpdate.State,
                Clue = userUpdate.Clue,
                UserRoleId = userUpdate.UserRoleId,
                Mail = userUpdate.Mail,
                FullName = userUpdate.FullName,
                UserID = userUpdate.UserId
            };
            this.userRepository.Update(user);

            return Ok();
        }
    }
}
