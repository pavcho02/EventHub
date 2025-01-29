using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class EventReview
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
