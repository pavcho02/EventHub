using System.Diagnostics;
using Business;
using Data.Models;
using EventHub.Models;
using EventHub.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventBusiness eventBusiness;

        public HomeController(IEventBusiness eventBusiness)
        {
            this.eventBusiness = eventBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomePageViewModel
            (
                new List<EventViewModel>(await eventBusiness.GetRecentEvents()),
                eventBusiness.GetTopRatedEvents()
            );
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
