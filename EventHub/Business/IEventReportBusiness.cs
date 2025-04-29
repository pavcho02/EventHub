using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IEventReportBusiness
    {
        public Task AddAsync(EventReport eventReport);

        public Task DeleteAsync(string eventId, string userId);

        public Task HandleReport(string eventId, string userId);

        public List<TModel> GetAllReportsByEventId<TModel>(string eventId, Func<EventReport, TModel> mapFunc);

    }
}
