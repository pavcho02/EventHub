using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Models.ViewModels
{
    public class EventReviewViewModel
    {
        public string UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string EventId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public EventReviewViewModel(string userId, string userFirstName, string userLastName,string eventId, int rating, string comment)
        {
            UserId = userId;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            EventId = eventId;
            Rating = rating;
            Comment = comment;
        }

        public EventReviewViewModel()
        {
            
        }
    }
}
