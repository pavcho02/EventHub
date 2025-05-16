using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EventHubDbContext : IdentityDbContext<User, UserRole, string>
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

            //Relationship one-to-many
            //An user can own multiple events, but an event can only have one owner
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedEvents)
                .WithOne(e => e.Owner)
                .OnDelete(DeleteBehavior.SetNull);

            //Relationship one-to-one
            //An user can have only one role request, and a role request belongs to one user
            modelBuilder.Entity<User>()
                .HasOne(u => u.RoleRequest)
                .WithOne(r => r.User)
                .HasForeignKey<RoleRequest>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relationship one-to-many
            //An event can only have one owner, but an user can own multiple events
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Owner)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            //The primary key for Participation is a composite key made up of the EventId and UserId 
            modelBuilder.Entity<Participation>()
                .HasKey(p => new { p.EventId, p.UserId });

            //Relationship many-to-many
            //An event can be attended by multiple users and an user can attend multiple events
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.User)
                .WithMany(u => u.EventsToAttend)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //The primary key for EventReview is a composite key made up of the EventId and UserId
            modelBuilder.Entity<EventReview>()
                .HasKey(ev => new { ev.EventId, ev.UserId });

            //Relationship many-to-many
            //An event can have multiple reviews and an user can review multiple events
            modelBuilder.Entity<EventReview>()
                .HasOne(ev => ev.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(ev => ev.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventReview>()
                .HasOne(ev => ev.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(ev => ev.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //The primary key for EventReport is a composite key made up of the EventId and UserIdq
            modelBuilder.Entity<EventReport>()
                .HasKey(er => new { er.EventId, er.UserId });

            //Relationship many-to-many
            //An event can have multiple reports and an user can report multiple events
            modelBuilder.Entity<EventReport>()
                .HasOne(er => er.Event)
                .WithMany(e => e.Reports)
                .HasForeignKey(er => er.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventReport>()
                .HasOne(er => er.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(er => er.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
        public DbSet<EventReport> EventReports { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<RoleRequest> RoleRequests { get; set; }
    }
}
