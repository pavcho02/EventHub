using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ParticipationBusiness
    {
        private readonly EventHubDbContext context;

        public ParticipationBusiness(EventHubDbContext context) 
        {
            this.context = context;
        }

        public async Task ParticipateToEvent(string userId, string eventId)
        {
            if(!context.Participations.Any(p => p.UserId == userId && p.EventId == eventId)
                || await context.Users.FindAsync(userId) != null || await context.Events.FindAsync(eventId) != null)
            {
                var participation = new Participation
                {
                    UserId = userId,
                    EventId = eventId
                };
                context.Participations.Add(participation);
                await context.SaveChangesAsync();
            }            
        }

        public async Task UnparticipateToEvent(string userId, string eventId)
        {
            if (!context.Participations.Any(p => p.UserId == userId && p.EventId == eventId)
                || await context.Users.FindAsync(userId) != null || await context.Events.FindAsync(eventId) != null)
            {
                var participation = await context.Participations
                    .FirstOrDefaultAsync(p => p.UserId == userId && p.EventId == eventId);
                context.Participations.Remove(participation);
                await context.SaveChangesAsync();
            }
        }
    }
}
