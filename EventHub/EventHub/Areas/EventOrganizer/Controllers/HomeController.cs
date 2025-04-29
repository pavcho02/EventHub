using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Areas.EventOrganizer.Controllers
{
    [Area("EventOrganizer")]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "EventOrganizer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
