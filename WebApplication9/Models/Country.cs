using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models;

public class Country
{
    [Key]
    public int IdCountry { get; set; }
    
    public string Name { get; set; }
    
    public virtual ICollection<Trip> IdTrips { get; set; } = new List<Trip>();
}