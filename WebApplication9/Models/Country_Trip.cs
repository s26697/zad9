using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models;

public class Country_Trip
{
    [Key]
    public int IdCountry { get; set; }
    [Key]
    public int IdTrip { get; set; }
}