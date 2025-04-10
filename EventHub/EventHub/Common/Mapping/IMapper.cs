using Data.Models;
using EventHub.Models.ViewModels;

namespace EventHub.Common.Mapping
{
    public interface IMapper
    {
        public RequestIndexViewModel MapToRequestIndexViewModel(RoleRequest roleRequest);

        public RequestDetailsViewModel MapToRequestDetailsViewModel (RoleRequest roleRequest);

        public EventReportViewModel MapToEventReportViewModel(EventReport eventReport);

        public EventReportIndexViewModel MapToEventReportIndexViewModel(Event eventItem);

        public EventReportDetailsViewModel EventReportDetailsViewModel(Event eventItem, List<EventReportViewModel> eventReports);

        public EventViewModel MapToEventViewModel(Event eventItem);
    }
}
