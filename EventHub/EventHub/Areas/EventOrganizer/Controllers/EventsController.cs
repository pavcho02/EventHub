using Business;
using Data.Models;
using EventHub.Common.Mapping;
using EventHub.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EventHub.Areas.EventOrganizer.Controllers
{
    [Area("EventOrganizer")]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "EventOrganizer")]
    public class EventsController : Controller
    {
        private readonly IEventBusiness eventBusiness;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public EventsController(IEventBusiness eventBusiness, UserManager<User> userManager, IMapper mapper)
        {
            this.eventBusiness = eventBusiness;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var model = eventBusiness.GetAllByCreator(currentUser.Id, mapper.MapToEventIndexViewModel);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string eventId)
        {
            var model = await eventBusiness.GetAsync(eventId, mapper.MapToEventDetailsViewModel);

            if (model == null)
            {
                NotFound();
            }

            return View(model);
        }

        //Fetch the event creation page
        [HttpGet]
        public IActionResult Create()
        {
            return View(new EventInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            var currentUser = userManager.GetUserAsync(User).Result;

            var eventToCreate = new Event()
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                StartTime = inputModel.StartTime,
                Location = inputModel.Location,
                TargetAudience = inputModel.TargetAudience,
                EventType = inputModel.EventType,
                OwnerId = currentUser.Id
            };

            await eventBusiness.AddAsync(eventToCreate);

            return RedirectToAction("Details", new { eventId = eventToCreate.Id });
        }

        //Fetch the event to be edited and the edit page
        [HttpGet]
        public async Task<IActionResult> Edit(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            var model = await eventBusiness.GetAsync(eventId, mapper.MapToEventInputModel);

            if (model == null)
            {
                NotFound();
            }
            
            return View(model);
        }             

        //Updates event's data
        [HttpPost]
        public async Task<IActionResult> Edit(string eventId, Event e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }

            var currentUser = await userManager.GetUserAsync(User);

            await eventBusiness.UpdateAsync(e, currentUser.Id);

            return RedirectToAction("Details", new { eventId = eventId });
        }

        public async Task<IActionResult> Delete(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            await eventBusiness.DeleteAsync(eventId, currentUser.Id);

            return RedirectToAction("Index");
        }
    }
}
