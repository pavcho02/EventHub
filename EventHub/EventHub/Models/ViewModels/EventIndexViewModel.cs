using Data.Enums;

namespace EventHub.Models.ViewModels
{
    public class EventIndexViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public EventType EventType { get; set; }

        public EventIndexViewModel(string eventId, string eventTitle, EventType eventType)
        {
            Id = eventId;
            Title = eventTitle;
            EventType = eventType;
        }

        public EventIndexViewModel()
        {
            
        }
    }
}
