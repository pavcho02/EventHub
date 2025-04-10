using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
