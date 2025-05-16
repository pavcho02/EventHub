namespace EventHub.Models.ViewModels
{
    public class RequestIndexViewModel
    {
        public string UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public RequestIndexViewModel(string userId, string userFirstName, string userLastName)
        {
            this.UserId = userId;
            this.UserFirstName = userFirstName;
            this.UserLastName = userLastName;
        }
        public RequestIndexViewModel()
        {
            
        }
    }
}
