using System.Globalization;

namespace EventHub.Models.ViewModels
{
    public class RequestDetailsViewModel : RequestIndexViewModel
    {
        public string UserEmail { get; set; }

        public DateOnly UserDateofBirth { get; set; }

        public string RequestDescription { get; set; }

        public RequestDetailsViewModel(string userId, string userFirstName, string userLastName, string userEmail, 
            DateOnly userBirthDate, string requestDescription) : base(userId, userFirstName, userLastName)
        {
            this.UserEmail = userEmail;
            this.RequestDescription = requestDescription;
            this.UserDateofBirth = userBirthDate;
        }
    }
}
