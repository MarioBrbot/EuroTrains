using EuroTrains.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuroTrains.Data
{
    public class Entities : DbContext
    {

        public DbSet<Passenger> Passengers => Set<Passenger>();
        public DbSet<Trains> Trains => Set<Trains>();

        public Entities(DbContextOptions<Entities> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().HasKey(p => p.Email);

            modelBuilder.Entity<Trains>().Property(p => p.RemainingNumberOfSeats)
              .IsConcurrencyToken();

            modelBuilder.Entity<Trains>().OwnsOne(f => f.Departure);
            modelBuilder.Entity<Trains>().OwnsOne(f => f.Arrival);
        }
    }
}
