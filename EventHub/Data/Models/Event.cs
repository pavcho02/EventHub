using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Event
    {
        public Event()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public TargerAudience TargetAudience { get; set; }

        public EventType EventType { get; set; }

        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<User> Participants { get; set; }
    }
}
