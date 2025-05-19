using Data.Models;
using EventHub.Models.InputModels;
using EventHub.Models.ViewModels;

namespace EventHub.Common.Mapping
{
    public interface IMapper
    {
        public RequestIndexViewModel MapToRequestIndexViewModel(RoleRequest roleRequest);

        public RequestDetailsViewModel MapToRequestDetailsViewModel (RoleRequest roleRequest);

        public EventReportViewModel MapToEventReportViewModel(EventReport eventReport);

        public EventReportIndexViewModel MapToEventReportIndexViewModel(Event eventItem);

        public EventReportDetailsViewModel EventReportDetailsViewModel(Event eventItem);

        public EventViewModel MapToEventViewModel(Event eventItem);

        public EventReviewViewModel MapToEventReviewViewModel(EventReview eventReview);

        public EventDetailsViewModel MapToEventDetailsViewModel(Event eventItem);

        public EventInputModel MapToEventInputModel(Event eventItem);

        public EventIndexViewModel MapToEventIndexViewModel(Event eventItem);

        public EventUpdateModel MapToEventUpdateModel(Event eventItem);
    }
}
