using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9.Models;

public class Client_Trip
{
    
    
    public int IdClient { get; set; }
   
    public int IdTrip { get; set; }
    
    public DateTime RegisteredAt { get; set; }
    
    public DateTime? PaymentDate { get; set; }
    
    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Trip IdTripNavigation { get; set; } = null!;
}