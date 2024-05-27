namespace WebApplication9.DTOs;

public record TripDTO(string Name, string Description, DateTime DateFrom, DateTime DateTo, int MaxPeople, List<CountryDTO> Countires, List<ClientDTO> Clients);