using WebApplication9.DTOs;
using WebApplication9.ENUM;
using WebApplication9.Models;
using WebApplication9.Repositories;

namespace WebApplication9.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
    public async Task<IEnumerable<TripDTO>> GetTrips()
    {
        return await _clientRepository.GetTrips();
    }

    public async Task<Errors> DeleteClient(int idClient)
    {
        return await _clientRepository.DeleteClient(idClient);
    }

    public async Task<Errors> AssignClientToTrip(ClientInputDTO clientInputDto)
    {
        return await _clientRepository.AssignClientToTrip(clientInputDto);
    }
}