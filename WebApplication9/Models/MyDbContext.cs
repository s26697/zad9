using Microsoft.EntityFrameworkCore;

namespace WebApplication9.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
       
    }
    
    
    
    public DbSet<Client> Client { get; set; }
    public DbSet<Client_Trip> Client_Trip { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Country_Trip> Country_Trip { get; set; }
    public DbSet<Trip> Trip { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client_Trip>()
            .HasKey(x => new { x.IdClient, x.IdTrip });
        
        modelBuilder.Entity<Country_Trip>()
            .HasKey(x => new { x.IdCountry, x.IdTrip });
    }
}
