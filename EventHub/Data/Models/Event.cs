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
            Participants = new HashSet<Participation>();
            Reviews = new HashSet<EventReview>();
            Reports = new HashSet<EventReport>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public TargerAudience TargetAudience { get; set; }

        public EventType EventType { get; set; }

        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Participation> Participants { get; set; }

        public virtual ICollection<EventReview> Reviews { get; set; }

        public virtual ICollection<EventReport> Reports { get; set; }
    }
}
