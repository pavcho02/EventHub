using Business;
using Data.Models;
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

        public EventsController(IEventBusiness eventBusiness, UserManager<User> userManager)
        {
            this.eventBusiness = eventBusiness;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var model = eventBusiness.GetAllByCreator(currentUser.Id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string eventId)
        {
            var model = eventBusiness.GetAsync(eventId);

            if (model == null)
            {
                NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventInputModel input)
        {
            var currentUser = await userManager.GetUserAsync(User);

            Event e = new Event();

            e.Owner = currentUser;
            e.OwnerId = currentUser.Id;
            e.Title = input.Title;
            e.Description = input.Description;
            e.Location = input.Location;
            e.StartTime = input.StartTime;
            e.TargetAudience = input.TargetAudience;
            e.EventType = input.EventType;

            await eventBusiness.AddAsync(e);

            return RedirectToAction("Details", e.Id);
        }

        //Fetch the event to be edited and the edit page
        [HttpGet]
        public async Task<IActionResult> Edit(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            var model = await eventBusiness.GetAsync(eventId);

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
            var currentUser = await userManager.GetUserAsync(User);

            await eventBusiness.UpdateAsync(e, currentUser.Id);

            return RedirectToAction("Details", eventId);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string eventId)
        {
            var currentUser = await userManager.GetUserAsync(User);

            await eventBusiness.DeleteAsync(eventId, currentUser.Id);

            return RedirectToAction("Index");
        }
    }
}
