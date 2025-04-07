using Microsoft.EntityFrameworkCore;

namespace POEPart1WebApplication.Models
{
    public class EventEaseDbContext : DbContext
    {
        // The constructor accepts options, which includes the connection string configured in Program.cs
        public EventEaseDbContext(DbContextOptions<EventEaseDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        // Remove the OnConfiguring method since we no longer need to configure the connection string here
        // The connection string will be injected via dependency injection
    }
}