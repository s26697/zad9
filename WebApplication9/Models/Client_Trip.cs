using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9.Models;

public class Client_Trip
{
    
    
    public int IdClient { get; set; }
   
    public int IdTrip { get; set; }
    
    public int RegisteredAt { get; set; }
    
    public int? PaymentDate { get; set; }
}