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
    public class ReportsController : Controller
    {
        private readonly IEventBusiness eventBusiness;
        private readonly IEventReportBusiness eventReportBusiness;
        private readonly IMapper mapper;

        public ReportsController(IEventBusiness eventBusiness, IEventReportBusiness eventReportBusiness, IMapper mapper)
        {
            this.eventBusiness = eventBusiness;
            this.eventReportBusiness = eventReportBusiness;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = eventBusiness.GetAllSummary<EventReportIndexViewModel>(mapper.MapToEventReportIndexViewModel);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var eventItem = await eventBusiness.GetAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            var model = mapper.EventReportDetailsViewModel(eventItem, 
                eventReportBusiness.GetAllReportsByEventId<EventReportViewModel>(eventItem.Id , mapper.MapToEventReportViewModel));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> HandleReport(string eventId, string userId)
        {
            await eventReportBusiness.HandleReport(eventId, userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReport(string eventId, string userId)
        {
            await eventReportBusiness.DeleteAsync(eventId, userId);
            return RedirectToAction("Index");
        }
    }
}
