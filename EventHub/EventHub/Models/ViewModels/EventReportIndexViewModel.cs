namespace EventHub.Models.ViewModels
{
    public class EventReportIndexViewModel
    {
        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public int reportsCount { get; set; }

        public EventReportIndexViewModel(string id, string title, int reportsCount)
        {
            this.EventId = id;
            this.EventTitle = title;
            this.reportsCount = reportsCount;
        }
    }
}
