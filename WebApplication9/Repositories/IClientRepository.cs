using WebApplication9.Models;

namespace WebApplication9.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClients();
    Task<Client> GetClientById(int id);
    Task<bool> DeleteClient(int id);
    Task <bool> AddClient(Client client);
        
}