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

        public async Task UpdateAsync(Event e, string userId)
        {
            var eventInContext = await context.Events.FindAsync(e);
            if (eventInContext != null && eventInContext.OwnerId == userId)
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

        public async Task<TModel> GetAsync<TModel>(string id, Func<Event, TModel> mapFunc)
        {
            return mapFunc(await context.Events.FindAsync(id));
        }

        public ICollection<TModel> GetAllByCreator<TModel>(string userId, Func<Event, TModel> mapFunc)
        {
            return context.Events.Where(e => e.OwnerId.Equals(userId)).Select(x => mapFunc(x)).ToList();
        }

        public async Task<ICollection<TModel>> GetAllAsync<TModel>(Func<Event, TModel> mapFunc)
        {
            return await context.Events.Select(x => mapFunc(x)).ToListAsync();
        }

        public ICollection<TModel> GetAllSummary<TModel>(Func<Event, TModel> mapFunc)
        {
            return context.Events.Select(mapFunc).ToList();
        }

        public async Task DeleteAsync(string eventId, string userId)
        {
            var eventInContext = await context.Events.FindAsync(eventId);
            if (eventInContext != null && eventInContext.OwnerId == userId)
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

        public async Task<ICollection<TModel>> GetRecentEvents<TModel>(Func<Event,TModel> mapFunc)
        {
            return await context.Events
                .Where(e => e.StartTime > DateTime.Now)
                .OrderBy(e => e.StartTime)
                .Select(x => mapFunc(x))
                .Take(10)
                .ToListAsync();
        }

        public async Task<ICollection<TModel>> GetTopRatedEvents<TModel>(Func<Event, TModel> mapFunc)
        {
            return await context.Events
                .OrderByDescending(e => e.Reviews.Average(r => r.Rating))
                .Select(x => mapFunc(x))
                .Take(10)
                .ToListAsync();
        }

    }
}
