namespace WebApplication9.DTOs;

public record ClientInputDTO(string FirstName, string LastName, string Email, String Telephone, string Pesel, int IdTrip, string TripName, DateTime PaymentDate);