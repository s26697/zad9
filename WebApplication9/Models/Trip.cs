using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models;

public class Trip
{
    [Key]
    public int IdTrip { get; set; }
    
    public string Name { get; set; }
   
    public string Description { get; set; }
    
    public DateTime DateFrom { get; set; }
   
    public DateTime DateTo { get; set; }
    
    public int MaxPeople { get; set; }
    
    
}