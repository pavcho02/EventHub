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
            this.context.Events.Add(e);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event e)
        {
            var eventInContext = await context.Events.FindAsync(e);
            if (eventInContext != null)
            {
                //to do - send email
                context.Entry(eventInContext).CurrentValues.SetValues(e);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Event> GetAsync(string id)
        {
            return await context.Events.FindAsync(id);
        }

        public ICollection<Event> GetAllByCreator(string userId)
        {
            return context.Events.Where(e => e.OwnerId == userId).ToList();
        }

        public async Task<ICollection<Event>> GetAllAsync()
        {
            return await context.Events.ToListAsync();
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
                //to do - send email
                context.Events.Remove(eventInContext);
                await context.SaveChangesAsync();
            }
        }
    }
}
