using Microsoft.AspNetCore.Mvc;
using WebApplication9.Repositories;
using WebApplication9.Services;

namespace WebApplication9.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

   

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _clientService.GetClientById(id);
        if (client == null ) // || HasTrips(client)
        {
            return NotFound();
        }

        if (await _clientService.DeleteClient(id))
        {
            return Ok();
        }
        return NoContent();
    }
    
   // public async Task<IActionResult> AddClient(int id)

   
}


