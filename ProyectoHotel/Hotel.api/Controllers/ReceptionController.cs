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

        [HttpGet("GetReceptionByClientId")]
        public IActionResult GetReceptionByClientId(int clientId)
        {
            var receptions = this.receptionRepository.GetReceptionByClient(clientId);
            return Ok(receptions);
        }

        [HttpGet("GetReceptionByRoomId")]
        public IActionResult GetReceptionByRoomId(int roomId)
        {
            var receptions = this.receptionRepository.GetReceptionByRoom(roomId);
            return Ok(receptions);
        }

        // GET: api/<ReceptionController>
        [HttpGet("GetReceptions")]
        public IActionResult Get()
        {
            var receptions = this.receptionRepository.GetEntities().Select(rc => new ReceptionGetAllModel() 
            {
                ChangeUser = rc.CreationUserId,
                ChanageDate = rc.RegistrationDate,
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
                ReceptionId = rc.ReceptionId
            }).ToList();

            return Ok(receptions);
        }

        // GET api/<ReceptionController>/5
        [HttpGet("GetReception")]
        public IActionResult GetReception(int id)
        {
            var Reception = this.receptionRepository.GetEntity(id);
            return Ok(Reception);
        }

        // POST api/<ReceptionController>
        [HttpPost("SaveReception")]
        public IActionResult Post([FromBody] ReceptionAddModel receptionAdd)
        {
            Reception reception = new Reception()
            {
                CreationUserId = receptionAdd.ChangeUser,
                RegistrationDate = receptionAdd.ChanageDate,
                State = receptionAdd.State,
                Observation = receptionAdd.Observation,
                CostPenalty = receptionAdd.CostPenalty,
                TotalPaid = receptionAdd.TotalPaid,
                RemainingPrice = receptionAdd.RemainingPrice,
                Advancement = receptionAdd.Advancement,
                StartingPrice = receptionAdd.StartingPrice,
                ConfirmationDepartureDate = receptionAdd.ConfirmationDepartureDate,
                DepartureDate = receptionAdd.DepartureDate,
                EntryDate = receptionAdd.EntryDate,
                RoomId = receptionAdd.RoomId,
                ClientId = receptionAdd.ClientId
            };
            this.receptionRepository.Save(reception);

            return Ok();
        }

        // PUT api/<ReceptionController>/5
        [HttpPut("UpdateReception")]
        public IActionResult Put([FromBody] ReceptionUpdateModel receptionUpdate)
        {
            Reception reception = new Reception()
            {
                CreationUserId = receptionUpdate.ChangeUser,
                RegistrationDate = receptionUpdate.ChanageDate,
                State = receptionUpdate.State,
                Observation = receptionUpdate.Observation,
                CostPenalty = receptionUpdate.CostPenalty,
                TotalPaid = receptionUpdate.TotalPaid,
                RemainingPrice = receptionUpdate.RemainingPrice,
                Advancement = receptionUpdate.Advancement,
                StartingPrice = receptionUpdate.StartingPrice,
                ConfirmationDepartureDate = receptionUpdate.ConfirmationDepartureDate,
                DepartureDate = receptionUpdate.DepartureDate,
                EntryDate = receptionUpdate.EntryDate,
                RoomId = receptionUpdate.RoomId,
                ClientId = receptionUpdate.ClientId,
                ReceptionId = receptionUpdate.ReceptionId
            };
            this.receptionRepository.Update(reception);

            return Ok();
        }
    }
}
