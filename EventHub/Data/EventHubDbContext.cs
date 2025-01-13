using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal class EventHubDbContext : IdentityDbContext<User, UserRole, string>
    {
        public EventHubDbContext(DbContextOptions<EventHubDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public EventHubDbContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationships between the entities


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
        public DbSet<EventReport> EventReports { get; set; }

    }
}
