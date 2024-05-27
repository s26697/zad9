using Microsoft.AspNetCore.Mvc;
using WebApplication9.DTOs;
using WebApplication9.ENUM;
using WebApplication9.Models;
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

   

    [HttpDelete("/api/clients/{idClient:int}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        var result = await _clientService.DeleteClient(idClient);
        if (result == Errors.BadRequest)
            return BadRequest("Cannot delete client with assigned trips");
        if (result == Errors.NotFound)
            return StatusCode(StatusCodes.Status404NotFound);
        return Ok(result);
    }
    
    [HttpPost("/api/trips/{idTrip}/clients")]
    public async Task<ActionResult> AssignClientToTrip(ClientInputDTO clientInputDto)
    {
        var result = await _clientService.AssignClientToTrip(clientInputDto);
        if (result == Errors.BadRequest)
            return BadRequest(StatusCodes.Status400BadRequest);
        if (result == Errors.NotFound)
            return StatusCode(StatusCodes.Status404NotFound);
        return Ok();
    }

    [HttpGet("/api/trips")]
    public async Task<IActionResult> GetTrips()
    {
        return Ok(await _clientService.GetTrips());
    }
}


