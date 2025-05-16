using Business;
using Data.Models;
using EventHub.Common.Mapping;
using EventHub.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "User")]

    public class EventsController : Controller
    {
        private readonly IEventBusiness eventBusiness;
        private readonly IEventReportBusiness eventReportBusiness;
        private readonly IEventReviewBusiness eventReviewBusiness;
        private readonly IParticipationBusiness participationBusiness;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public EventsController(IEventBusiness eventBusiness, IEventReportBusiness eventReportBusiness, 
            IParticipationBusiness participationBusiness, IEventReviewBusiness eventReviewBusiness,
            UserManager<User> userManager, IMapper mapper)
        {
            this.eventBusiness = eventBusiness;
            this.eventReportBusiness = eventReportBusiness;
            this.eventReviewBusiness = eventReviewBusiness;
            this.participationBusiness = participationBusiness;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string eventId)
        {
            var eventDetails = await eventBusiness.GetAsync(eventId, mapper.MapToEventDetailsViewModel);
            if (eventDetails == null)
            {
                return NotFound("Event not found!");
            }
            return View(eventDetails);
        }

        // Renders the review form
        [HttpGet]
        public async Task<IActionResult> Review(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var model = new EventReviewInputModel()
            {
                EventId = eventId
            };
            if (currentUser.Reviews.Any(r => r.EventId == eventId))
            {
                var existingReview = currentUser.Reviews.FirstOrDefault(r => r.EventId == eventId);
                model.Rating = existingReview.Rating;
                model.Comment = existingReview.Comment;
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Review(EventReviewInputModel inputModel)
        {

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            var currentUser = await userManager.GetUserAsync(User);

            var review = new EventReview()
            {
                Comment = inputModel.Comment,
                Rating = inputModel.Rating,
                UserId = currentUser.Id,
                EventId = inputModel.EventId
            };

            await eventReviewBusiness.AddAsync(review);

            return RedirectToAction("Details", new { eventId = inputModel.EventId});
        }

        // Renders the report form
        [HttpGet]
        public IActionResult Report(string eventId)
        {
            var model = new EventReportInputModel()
            {
                EventId = eventId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Report(EventReportInputModel inputModel)
        {
            if(!ModelState.IsValid)
            {
                return View(inputModel);
            }

            var currentUser = await userManager.GetUserAsync(User);

            var report = new EventReport()
            {
                Description = inputModel.Description,
                UserId = currentUser.Id,
                EventId = inputModel.EventId
            };

            await eventReportBusiness.AddAsync(report);

            return RedirectToAction("Details", new { eventId = inputModel.EventId });
        }

        public async Task<IActionResult> Participate(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            await participationBusiness.ParticipateToEvent(currentUser.Id, eventId);

            return RedirectToAction("Details", new { eventId = eventId });
        }

        public async Task<IActionResult> UnParticipate(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            await participationBusiness.UnParticipateToEvent(currentUser.Id, eventId);

            return RedirectToAction("Details", new { eventId = eventId });
        }

        public async Task<IActionResult> DeleteReview(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            await eventReviewBusiness.DeleteAsync(eventId, currentUser.Id);
            return RedirectToAction("Details", new { eventId = eventId });
        }
    }
}
