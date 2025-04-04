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
    public class EventReviewBusiness : IEventReviewBusiness
    {
        private readonly EventHubDbContext context;

        public EventReviewBusiness(EventHubDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(EventReview eventReview)
        {
            await context.EventReviews.AddAsync(eventReview);
            await context.SaveChangesAsync();
        }

        public async Task<EventReview?> GetAsync(string eventId, string userId)
        {
            return await context.EventReviews.FindAsync(eventId, userId);
        }

        public async Task<ICollection<EventReview>> GetAllByEventAsync(string eventId)
        {
            return await context.EventReviews.Where(ev => ev.EventId.Equals(eventId)).ToListAsync();
        }

        public async Task<ICollection<EventReview>> GetAllByUserAsync(string userId)
        {
            return await context.EventReviews.Where(ev => ev.UserId.Equals(userId)).ToListAsync();
        }

        public async Task UpdateAsync(EventReview eventReview)
        {
            var eventReviewInContext = await context.EventReviews.FindAsync(eventReview.EventId, eventReview.UserId);
            if(eventReviewInContext != null)
            {
                context.Entry(eventReviewInContext).CurrentValues.SetValues(eventReview);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string eventId, string userId)
        {
            var eventReviewInContext = await context.EventReviews.FindAsync(eventId, userId);
            if (eventReviewInContext != null)
            {
                context.EventReviews.Remove(eventReviewInContext);
                await context.SaveChangesAsync();
            }
        }
    }
}
