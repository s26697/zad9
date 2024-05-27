using WebApplication9.Models;

namespace WebApplication9.Services;

public interface IClientService
{
    Task<Client> GetClientById(int id);
    Task<bool> DeleteClient(int id);
    
    Task<bool> AddClient(Client client);
    
    Task<IEnumerable<Client>> GetAllClients();
}