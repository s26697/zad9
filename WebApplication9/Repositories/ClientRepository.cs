using Microsoft.EntityFrameworkCore;
using WebApplication9.DTOs;
using WebApplication9.ENUM;
using WebApplication9.Models;

namespace WebApplication9.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly MyDbContext _dbContext;

    public ClientRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

   
    

    public async Task<Errors> DeleteClient(int idClient)
    {
      
        
        var client = await _dbContext.Client.FindAsync(idClient);
        if (client == null)
            return Errors.NotFound;

        if (_dbContext.Client_Trip.Any(ct => ct.IdClient == idClient))
            return Errors.BadRequest;

         _dbContext.Client.Remove(client);
        await _dbContext.SaveChangesAsync();

        return Errors.Good;
    }
    public async Task<Errors> AssignClientToTrip(ClientInputDTO clientInputDto)
    {
        
        
        var existingClient = await _dbContext.Client.FirstOrDefaultAsync(c => c.Pesel == clientInputDto.Pesel);
        if (existingClient != null)
            return Errors.BadRequest;

        var trip = await _dbContext.Trip.FindAsync(clientInputDto.IdTrip);
        if (trip == null)
            return Errors.NotFound;

        if (trip.DateFrom <= DateTime.Now)
            return Errors.BadRequest;

        var client = new Client
        {
            FirstName = clientInputDto.FirstName,
            LastName = clientInputDto.LastName,
            Email = clientInputDto.Email,
            Telephone = clientInputDto.Telephone,
            Pesel = clientInputDto.Pesel
        };

        var clientTrip = new Client_Trip
        {
            IdClient = existingClient.IdClient,
            IdTrip = clientInputDto.IdTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = clientInputDto.PaymentDate
        };

        _dbContext.Client_Trip.Add(clientTrip);
        _dbContext.SaveChanges();

        return Errors.Good;
    }

    public async Task<IEnumerable<TripDTO>> GetTrips()
    {
        

        List<TripDTO> trips = await _dbContext.Trip
            .OrderByDescending(t => t.DateFrom)
            .Select(x => new TripDTO
            (
                x.Name, 
                x.Description, 
                x.DateFrom, 
                x.DateTo, 
                x.MaxPeople, 
                x.IdCountries.Select(c => new CountryDTO
                (
                    c.Name
                )).ToList(),
                x.ClientTrips.Select(ct => new ClientDTO
                (
                    ct.IdClientNavigation.FirstName,
                    ct.IdClientNavigation.LastName
                )).ToList()
            ))
            .ToListAsync();

        return trips;
    }
    
    
}