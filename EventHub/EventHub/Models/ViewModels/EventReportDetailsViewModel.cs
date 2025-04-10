using Data.Enums;

namespace EventHub.Models.ViewModels
{
    public class EventReportDetailsViewModel
    {
        public string EventTitle { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventStartTime { get; set; }

        public DateTime EventEndTime { get; set; }

        public string EventLocation { get; set; }

        public TargerAudience EventTargetAudience { get; set; }

        public EventType EventType { get; set; }

        public string EventOwnerFirstName { get; set; }

        public string EventOwnerLastName { get; set; }

        public string EventOwnerEmail { get; set; }

        public List<EventReportViewModel> EventReports;

        public EventReportDetailsViewModel(string eventTitle, string eventDescription, DateTime eventStartTime, 
            DateTime eventEndTime, TargerAudience eventTargetAudience, string eventLocation,EventType eventType, 
            string eventOwnerFirstName, string eventOwnerLastName, string eventOwnerEmail, List<EventReportViewModel> eventReports)
        {
            this.EventTitle = eventTitle;
            this.EventDescription = eventDescription;
            this.EventStartTime = eventStartTime;
            this.EventEndTime = eventEndTime;
            this.EventLocation = eventLocation;
            this.EventTargetAudience = eventTargetAudience;
            this.EventType = eventType;
            this.EventOwnerFirstName = eventOwnerFirstName;
            this.EventOwnerLastName = eventOwnerLastName;
            this.EventOwnerEmail = eventOwnerEmail;
            this.EventReports = eventReports;
        }
    }
}
