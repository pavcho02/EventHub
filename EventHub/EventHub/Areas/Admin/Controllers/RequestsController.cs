using Business;
using EventHub.Common.Mapping;
using EventHub.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin")]
    public class RequestsController : Controller
    {
        private readonly IRoleRequestBusiness roleRequestBusiness;
        public readonly IMapper mapper;
        public RequestsController(IRoleRequestBusiness roleRequestBusiness, IMapper mapper)
        {
            this.roleRequestBusiness = roleRequestBusiness;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = roleRequestBusiness.GetAll<RequestIndexViewModel>(mapper.MapToRequestIndexViewModel);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            var model = await roleRequestBusiness.GetByUserAsync<RequestDetailsViewModel>(userId, mapper.MapToRequestDetailsViewModel);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> ApproveRequest(string userId)
        {
            await roleRequestBusiness.ApproveRoleChangeAsync(userId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RejectRequest(string userId)
        {
            await roleRequestBusiness.RejectRoleChangeAsync(userId);

            return RedirectToAction("Index");
        }
    }
}
