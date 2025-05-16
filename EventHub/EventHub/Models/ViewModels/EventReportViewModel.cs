namespace EventHub.Models.ViewModels
{
    public class EventReportViewModel
    {
        public string EventId { get; set; }

        public string AuthorId { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string AuthorEmail { get; set; }

        public string ReportDescription { get; set; }

        public EventReportViewModel(string eventId, string authorId, string authorFirstName, string authorLastName, string authorEmail, string reportDescription)
        {
            this.EventId = eventId;
            this.AuthorId = authorId;
            this.AuthorFirstName = authorFirstName;
            this.AuthorLastName = authorLastName;
            this.AuthorEmail = authorEmail;
            this.ReportDescription = reportDescription;
        }

        public EventReportViewModel()
        {
            
        }
    }
}
