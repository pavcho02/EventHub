using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IParticipationBusiness
    {
        public Task ParticipateToEvent(string userId, string eventId);

        public Task UnparticipateToEvent(string userId, string eventId);
    }
}
