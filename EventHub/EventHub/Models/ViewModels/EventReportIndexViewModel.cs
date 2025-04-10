namespace EventHub.Models.ViewModels
{
    public class EventReportIndexViewModel
    {
        public string EventTitle { get; set; }

        public int reportsCount { get; set; }

        public EventReportIndexViewModel(string title, int reportsCount)
        {
            this.EventTitle = title;
            this.reportsCount = reportsCount;
        }
    }
}
