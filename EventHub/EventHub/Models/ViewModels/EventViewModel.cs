using Data.Enums;

namespace EventHub.Models.ViewModels
{
    public class EventViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public DateTime StartTime { get; set; }

        public EventType EventType { get; set; }

        public EventViewModel(string id, string title, double rating, DateTime startTime, EventType eventType)
        {
            this.Id = id;
            this.Title = title;
            this.Rating = rating;
            this.StartTime = startTime;
            this.EventType = eventType;
        }

        public EventViewModel()
        {
            
        }
    }
}
