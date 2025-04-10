using Data.Models;

namespace EventHub.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<EventViewModel> UpcomingEvents { get; set; }

        public List<EventViewModel> TopRatedEvents { get; set; }

        public HomePageViewModel(List<EventViewModel> upcomingEvents, List<EventViewModel> topRatedEvents)
        {
            this.UpcomingEvents = upcomingEvents;
            this.TopRatedEvents = topRatedEvents;
        }
    }
}
