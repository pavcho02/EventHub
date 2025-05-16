using System.Diagnostics;
using Business;
using Data.Models;
using EventHub.Common.Mapping;
using EventHub.Models;
using EventHub.Models.InputModels;
using EventHub.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventBusiness eventBusiness;

        private readonly IRoleRequestBusiness roleRequestBusiness;

        private readonly UserManager<User> userManager;

        private readonly IMapper mapper;

        public HomeController(IEventBusiness eventBusiness, UserManager<User> userManager,
             IRoleRequestBusiness roleRequestBusiness, IMapper mapper)
        {
            this.eventBusiness = eventBusiness;
            this.userManager = userManager;
            this.roleRequestBusiness = roleRequestBusiness;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomePageViewModel
                (
                    eventBusiness.GetRecentEvents(mapper.MapToEventViewModel).Result.ToList(),
                    eventBusiness.GetTopRatedEvents(mapper.MapToEventViewModel).Result.ToList()
                );

            return View(viewModel);
        }

        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult UpgradeAccount()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> UpgradeAccount(RoleRequestInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            var currentUser = await userManager.GetUserAsync(User);

            await roleRequestBusiness.RequestRoleChangeAsync(currentUser.Id, inputModel.Description);

            return RedirectToAction("Index");
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
