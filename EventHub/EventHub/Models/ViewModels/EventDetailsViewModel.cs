using Data.Enums;
using Data.Models;

namespace EventHub.Models.ViewModels
{
    public class EventDetailsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public string Location { get; set; }

        public TargetAudience TargetAudience { get; set; }

        public EventType EventType { get; set; }

        public ICollection<EventReviewViewModel> Reviews { get; set; }

        public ICollection<Participation> Participants { get; set; }

        public EventDetailsViewModel(string id, string title, string description, DateTime startTime, string location,
             TargetAudience targetAudience, EventType eventType, ICollection<EventReviewViewModel> Reviews, 
             ICollection<Participation> Participants)
        {
            Id = id;
            Title = title;
            Description = description;
            StartTime = startTime;
            Location = location;
            TargetAudience = targetAudience;
            EventType = eventType;
            this.Reviews = Reviews;
            this.Participants = Participants;
        }

        public EventDetailsViewModel()
        {
            
        }
    }
}
