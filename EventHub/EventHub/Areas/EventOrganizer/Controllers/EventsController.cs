using Business;
using Data.Models;
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

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            var model = eventBusiness.GetAllByCreator(currentUser.Id);
            return View(model);
        }

        public IActionResult Details(string eventId)
        {
            var model = eventBusiness.GetAsync(eventId);
            if (model == null)
            {
                NotFound();
            }
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var currentUser = await userManager.GetUserAsync(User);

            Event e = new Event();
            e.Owner = currentUser;
            e.OwnerId = currentUser.Id;

            await eventBusiness.AddAsync(e);

            return RedirectToAction("Details", e.Id);
        }

        public async Task<IActionResult> Edit(string eventId, Event e)
        {
            await eventBusiness.UpdateAsync(e);
            return RedirectToAction("Details", eventId);
        }

        public async Task<IActionResult> Delete(string eventId)
        {
            await eventBusiness.DeleteAsync(eventId);
            return RedirectToAction("Index");
        }
    }
}
