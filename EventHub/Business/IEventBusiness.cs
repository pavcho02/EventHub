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

        public Task UpdateAsync(Event e, string userId);

        public Task<TModel> GetAsync<TModel>(string id, Func<Event, TModel> mapFunc);

        public ICollection<TModel> GetAllByCreator<TModel>(string userId, Func<Event, TModel> mapFunc);

        public Task<ICollection<TModel>> GetAllAsync<TModel>(Func<Event, TModel> mapFunc);

        public ICollection<TModel> GetAllSummary<TModel>(Func<Event, TModel> mapFunc);

        public Task DeleteAsync(string eventId, string userId);

        public Task<ICollection<TModel>> GetRecentEvents<TModel>(Func<Event, TModel> mapFunc);

        public Task<ICollection<TModel>> GetTopRatedEvents<TModel>(Func<Event, TModel> mapFunc);
    }
}
