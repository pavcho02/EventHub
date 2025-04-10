using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class EventBusiness : IEventBusiness
    {
        private readonly EventHubDbContext context;
        private readonly IEmailSender emailSender;

        public EventBusiness(EventHubDbContext context, IEmailSender emailSender)
        {
            this.context = context;
            this.emailSender = emailSender;
        }

        public async Task AddAsync(Event e)
        {
            context.Events.Add(e);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Event e)
        {
            var eventInContext = await context.Events.FindAsync(e);
            if (eventInContext != null)
            {
                context.Entry(eventInContext).CurrentValues.SetValues(e);
                await context.SaveChangesAsync();

                // Send email to all participants about the update
                foreach (var p in e.Participants)
                {
                    await emailSender.SendEventUpdateEmailAsync(p.User.Email, e);
                }
            }
        }

        public async Task<Event?> GetAsync(string id)
        {
            return await context.Events.FindAsync(id);
        }

        public ICollection<Event> GetAllByCreator(string userId)
        {
            return context.Events.Where(e => e.OwnerId.Equals(userId)).ToList();
        }

        public async Task<ICollection<Event>> GetAllAsync()
        {
            return await context.Events.ToListAsync();
        }

        public ICollection<TModel> GetAllSummary<TModel>(Func<Event, TModel> mapFunc)
        {
            return context.Events.Select(mapFunc).ToList();
        }


        public bool IsAlreadyAdded(string name)
        {
            return context.Events.Any(e => e.Title.ToLower().Equals(name.ToLower()));
        }

        public async Task DeleteAsync(string id)
        {
            var eventInContext = await context.Events.FindAsync(id);
            if (eventInContext != null)
            {
                context.Events.Remove(eventInContext);
                await context.SaveChangesAsync();

                // Send email to all participants about the cancellation
                foreach (var p in eventInContext.Participants)
                {
                    await emailSender.SendEventCancelationEmailAsync(p.User.Email, eventInContext);
                }
            }
        }

        public async Task<double> CalculateEventRating(string eventId)
        {
            var reviews = await context.EventReviews.Where(er => er.EventId == eventId).ToListAsync();
            if (reviews.Any())
            {
                return reviews.Average(r => r.Rating);
            }
            else
            {
                return 0;
            }
        }

        public async Task<ICollection<Event>> GetRecentEvents()
        {
            return await context.Events
                .Where(e => e.StartTime > DateTime.Now)
                .OrderBy(e => e.StartTime)
                .Take(10)
                .ToListAsync();
        }

        public async Task<ICollection<Event>> GetTopRatedEvents()
        {
            return await context.Events
                .OrderByDescending(e => e.Reviews.Average(r => r.Rating))
                .Take(10)
                .ToListAsync();
        }

    }
}
