using Data.Models;
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

    }
}
