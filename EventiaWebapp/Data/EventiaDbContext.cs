using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Data
{
    public class EventiaDbContext : IdentityDbContext<User>
    {
        public EventiaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(e => e.HostedEvent)
                .WithOne(e => e.Organizer)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(modelBuilder);

        }
    }
}
