using Data.Models;

namespace EventHub.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<EventViewModel> UpcomingEvents { get; set; }

        public List<EventViewModel> TopRatedEvents { get; set; }

        public HomePageViewModel(List<EventViewModel> UpcomingEvents, List<EventViewModel> TopRatedEvents)
        {
            this.UpcomingEvents = UpcomingEvents;
            this.TopRatedEvents = TopRatedEvents;
        }
    }
}
