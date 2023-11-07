using Hotel.Api.Client;
using Hotel.domain.Entities;
using Hotel.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Hotel.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        // GET: api/<ClientController>
        [HttpGet("GetClients")]
        public IActionResult Get()
        {
            var clients = this.clientRepository.GetEntities()
                                               .Select(Client =>
                                               new GetClientModel()
                                               {
                                                   ClientId = Client.ClientId,
                                                   FullName = Client.FullName,
                                                    Document = Client.Document,
                                                    DocumentType= Client.DocumentType,
                                                    Mail     = Client.Mail,
                                                    State = Client.State,
                                               }).ToList();
                                   return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{GetClientId}")]
        public IActionResult GetClient(int id)
        {
            var Client = this.clientRepository.GetEntity(id);
            return Ok(Client);
           
        }

        // POST api/<ClientController>
         [HttpPost("SaveClient")]
        public IActionResult Post([FromBody] AddClientModel clientApp)
        {
        
            //this.clientRepository.Save(new Client()
            //{
            //    FullName = clientApp.FullName,
            //    Document = clientApp.Document,
            //    DocumentType = clientApp.DocumentType,
            //    Mail = clientApp.Mail,
            //    State = clientApp.State,
            //});



            return Ok();
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
