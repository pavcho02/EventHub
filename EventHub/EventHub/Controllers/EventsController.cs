using Business;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Controllers
{
    [Area("User")]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "User")]

    public class EventsController : Controller
    {
        private readonly IEventBusiness eventBusiness;
        private readonly IEventReportBusiness eventReportBusiness;
        private readonly IEventReviewBusiness eventReviewBusiness;
        private readonly IParticipationBusiness participationBusiness;
        private readonly UserManager<User> userManager;

        public EventsController(IEventBusiness eventBusiness, IEventReportBusiness eventReportBusiness, 
            IParticipationBusiness participationBusiness, IEventReviewBusiness eventReviewBusiness, UserManager<User> userManager)
        {
            this.eventBusiness = eventBusiness;
            this.eventReportBusiness = eventReportBusiness;
            this.eventReviewBusiness = eventReviewBusiness;
            this.participationBusiness = participationBusiness;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string eventId)
        {
            return View();
        }

        public async Task<IActionResult> Review(string eventId, string reviewComment, int reviewRating)
        {
            var currentUser = await userManager.GetUserAsync(User);

            var review = new EventReview()
            {
                Comment = reviewComment,
                Rating = reviewRating,
                UserId = currentUser.Id,
                EventId = eventId
            };

            await eventReviewBusiness.AddAsync(review);

            return RedirectToAction("Details", eventId);
        }

        public async Task<IActionResult> Report(string eventId, string reportDescription)
        {
            var currentUser = await userManager.GetUserAsync(User);

            var report = new EventReport()
            {
                Description = reportDescription,
                UserId = currentUser.Id,
                EventId = eventId
            };

            await eventReportBusiness.AddAsync(report);

            return RedirectToAction("Details", eventId);
        }

        public async Task<IActionResult> Participate(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            await participationBusiness.ParticipateToEvent(currentUser.Id, eventId);

            return RedirectToAction("Details", eventId);
        }

        public async Task<IActionResult> UnParticipate(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            await participationBusiness.UnParticipateToEvent(currentUser.Id, eventId);

            return RedirectToAction("Details", eventId);
        }
    }
}
