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
        private readonly IReceptionRepository receptionRepository;

        public ReceptionController(IReceptionRepository receptionRepository) 
        {
            this.receptionRepository = receptionRepository;
        }    
        // GET: api/<ReceptionController>
        [HttpGet]
        public IEnumerable<Reception> Get()
        {
            var receptions = this.receptionRepository.GetEntities();
            return receptions;
        }

        // GET api/<ReceptionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReceptionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReceptionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
