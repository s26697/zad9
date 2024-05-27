using WebApplication9.DTOs;
using WebApplication9.ENUM;
using WebApplication9.Models;

namespace WebApplication9.Services;

public interface IClientService
{
    Task<IEnumerable<TripDTO>> GetTrips();
    Task<Errors> DeleteClient(int idClient);
    Task<Errors> AssignClientToTrip(ClientInputDTO clientInputDto);
    
    
}