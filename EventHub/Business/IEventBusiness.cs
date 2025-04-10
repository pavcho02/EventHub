using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.Extensions.Logging;

namespace Business
{
    public interface IEventBusiness
    {
        public Task AddAsync(Event e);

        public Task UpdateAsync(Event e);

        public Task<Event?> GetAsync(string id);

        public ICollection<Event> GetAllByCreator(string userId);

        public Task<ICollection<Event>> GetAllAsync();

        public ICollection<TModel> GetAllSummary<TModel>(Func<Event, TModel> mapFunc);

        public Task DeleteAsync(string id);

        public bool IsAlreadyAdded(string name);

        public Task<double> CalculateEventRating(string eventId);

        public Task<ICollection<Event>> GetRecentEvents();

        public Task<ICollection<Event>> GetTopRatedEvents();
    }
}
