using Hotel.api.Models.Modules.Reception;
using Hotel.application.Contracts;
using Hotel.application.Dtos.Reception;
using Hotel.domain.Entities;
using Hotel.infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {
        private readonly IReceptionService receptionService;

        public ReceptionController(IReceptionService receptionService) 
        {
            this.receptionService = receptionService;
        }
        // GET: api/<ReceptionController>
        [HttpGet("GetReceptions")]
        public IActionResult Get()
        {
            var result = this.receptionService.GetAll();

            if (!result.Success) 
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<ReceptionController>/5
        [HttpGet("GetReception")]
        public IActionResult GetReception(int id)
        {
            var result = this.receptionService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/<ReceptionController>
        [HttpPost("SaveReception")]
        public IActionResult Post([FromBody] ReceptionDtoAdd receptionAdd)
        {
            var result = this.receptionService.Save(receptionAdd);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<ReceptionController>/5
        [HttpPut("UpdateReception")]
        public IActionResult Put([FromBody] ReceptionDtoUpdate receptionUpdate)
        {
            var result = this.receptionService.Update(receptionUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("RemoveReception")]
        public IActionResult Remove([FromBody] ReceptionDtoRemove receptionDtoRemove)
        {
            var result = this.receptionService.Remove(receptionDtoRemove);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }
    }
}
