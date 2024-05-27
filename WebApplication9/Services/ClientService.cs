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
    
    public async Task<Client> GetClientById(int id)
    {
        return await _clientRepository.GetClientById(id);
    }

    public async Task<bool> DeleteClient(int id)
    {
        return await _clientRepository.DeleteClient(id);
    }

    public async Task<bool> AddClient(Client client)
    {
        return await _clientRepository.AddClient(client);
    }

    public async Task<IEnumerable<Client>> GetAllClients()
    {
        return await _clientRepository.GetAllClients();
    }
}