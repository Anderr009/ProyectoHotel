using Hotel.api.Models.Modules.Reception;
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
        [HttpGet("GetReceptions")]
        public IActionResult Get()
        {
            var receptions = this.receptionRepository.GetEntities().Select(rc => new GetReceptionModel() 
            {
                RegistrationDate = rc.RegistrationDate,
                State = rc.State,
                Observation = rc.Observation,
                CostPenalty = rc.CostPenalty,
                TotalPaid = rc.TotalPaid,
                RemainingPrice = rc.RemainingPrice,
                Advancement = rc.Advancement,
                StartingPrice = rc.StartingPrice,
                ConfirmationDepartureDate = rc.ConfirmationDepartureDate,
                DepartureDate = rc.DepartureDate,
                EntryDate = rc.EntryDate,
                RoomId = rc.RoomId,
                ClientId = rc.ClientId,
                ReceptionId = rc.ReceptionId,
            });

            return Ok(receptions);
        }

        // GET api/<ReceptionController>/5
        [HttpGet("GetReception")]
        public IActionResult Get(int id)
        {
            var reception = this.receptionRepository.GetEntity(id);

            GetReceptionModel receptionModel = new GetReceptionModel()
            {
                RegistrationDate = reception.RegistrationDate,
                State = reception.State,
                Observation = reception.Observation,
                CostPenalty = reception.CostPenalty,
                TotalPaid = reception.TotalPaid,
                RemainingPrice = reception.RemainingPrice,
                Advancement = reception.Advancement,
                StartingPrice = reception.StartingPrice,
                ConfirmationDepartureDate = reception.ConfirmationDepartureDate,
                DepartureDate = reception.DepartureDate,
                EntryDate = reception.EntryDate,
                RoomId = reception.RoomId,
                ClientId = reception.ClientId,
                ReceptionId = reception.ReceptionId,
            };
            return Ok(receptionModel);
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
