using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Services;
using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("individual")]
        public async Task<IActionResult> AddIndividualClient([FromBody] IndividualClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.AddClient(clientDto);
            return Ok(client);
        }

        [HttpPost("company")]
        public async Task<IActionResult> AddCompanyClient([FromBody] CompanyClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.AddClient(clientDto);
            return Ok(client);
        }

        [HttpDelete("individual/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIndividualClient(int id)
        {
            var result = await _clientService.DeleteClient(id);
            if (!result)
            {
                return NotFound("Client not found");
            }
            return Ok("Individual client deleted successfully");
        }

        [HttpDelete("company/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCompanyClient(int id)
        {
            var result = await _clientService.DeleteClient(id);
            if (!result)
            {
                return NotFound("Client not found");
            }
            return Ok("Company client deleted successfully");
        }


        [HttpPut("individual/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateIndividualClient(int id, [FromBody] IndividualClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.UpdateClient(id, clientDto);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut("company/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCompanyClient(int id, [FromBody] CompanyClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.UpdateClient(id, clientDto);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}
