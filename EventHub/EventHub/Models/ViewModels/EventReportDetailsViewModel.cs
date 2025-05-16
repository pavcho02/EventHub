using Data.Enums;

namespace EventHub.Models.ViewModels
{
    public class EventReportDetailsViewModel
    {
        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventStartTime { get; set; }

        public string EventLocation { get; set; }

        public TargetAudience EventTargetAudience { get; set; }

        public EventType EventType { get; set; }

        public string EventOwnerFirstName { get; set; }

        public string EventOwnerLastName { get; set; }

        public string EventOwnerEmail { get; set; }

        public List<EventReportViewModel> EventReports;

        public EventReportDetailsViewModel(string id, string eventTitle, string eventDescription, DateTime eventStartTime, 
            TargetAudience eventTargetAudience, string eventLocation,EventType eventType, 
            string eventOwnerFirstName, string eventOwnerLastName, string eventOwnerEmail, List<EventReportViewModel> eventReports)
        {
            this.EventId = id;
            this.EventTitle = eventTitle;
            this.EventDescription = eventDescription;
            this.EventStartTime = eventStartTime;
            this.EventLocation = eventLocation;
            this.EventTargetAudience = eventTargetAudience;
            this.EventType = eventType;
            this.EventOwnerFirstName = eventOwnerFirstName;
            this.EventOwnerLastName = eventOwnerLastName;
            this.EventOwnerEmail = eventOwnerEmail;
            this.EventReports = eventReports;
        }

        public EventReportDetailsViewModel()
        {
            
        }
    }
}
