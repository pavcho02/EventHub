using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IEventReviewBusiness
    {
        public Task AddAsync(EventReview eventReview);

        public Task<EventReview?> GetAsync(string eventId, string userId);

        public Task<ICollection<EventReview>> GetAllByEventAsync(string eventId);

        public Task<ICollection<EventReview>> GetAllByUserAsync(string userId);

        public Task UpdateAsync(EventReview eventReview);

        public Task DeleteAsync(string eventId, string userId);
    }
}

