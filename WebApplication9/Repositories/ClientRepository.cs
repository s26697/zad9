using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly MyDbContext _dbContext;

    public ClientRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Client>> GetAllClients()
    {
        return await _dbContext.Client.ToListAsync();
    }

    public async Task<Client> GetClientById(int id)
    {
        return await _dbContext.Client.FindAsync(id);
    }


    public async Task<bool> DeleteClient(int id)
    {
        var client = await _dbContext.Client.FindAsync(id);
        if (client == null)
        {
            return false; 
        }

       
        if (_dbContext.Client_Trip.Any(ct => ct.IdClient == client.IdClient))
        {
            throw new InvalidOperationException("Klient ma przypisane wycieczki.");
        }

        _dbContext.Client.Remove(client);
        await _dbContext.SaveChangesAsync();
        return true; 
    }
    public async Task<bool> AddClient(Client client)
    {
        _dbContext.Client.Add(client);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    
}