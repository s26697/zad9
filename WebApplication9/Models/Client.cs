using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models;

public class Client
{
   [Key]
    public int IdClient { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!; 
    
    public string Telephone { get; set; } = null!;
    
    public string Pesel { get; set; } = null!;
    
    public virtual ICollection<Client_Trip> ClientTrips { get; set; } = new List<Client_Trip>();
    
}