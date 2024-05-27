using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models;

public class Trip
{
    [Key]
    public int IdTrip { get; set; }
    
    public string Name { get; set; } = null!;
   
    public string Description { get; set; } = null!;
    
    public DateTime DateFrom { get; set; }
   
    public DateTime DateTo { get; set; }
    
    public int MaxPeople { get; set; }
    
    public virtual ICollection<Client_Trip> ClientTrips { get; set; } = new List<Client_Trip>();

    public virtual ICollection<Country> IdCountries { get; set; } = new List<Country>();
    
    
}