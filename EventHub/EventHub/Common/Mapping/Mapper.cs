using Data.Models;
using EventHub.Models.ViewModels;

namespace EventHub.Common.Mapping
{
    public class Mapper : IMapper
    {
        public RequestIndexViewModel MapToRequestIndexViewModel(RoleRequest roleRequest)
        {
            return new RequestIndexViewModel(roleRequest.UserId, roleRequest.User.FirstName, roleRequest.User.LastName);
        }

        public RequestDetailsViewModel MapToRequestDetailsViewModel(RoleRequest roleRequest)
        {
            return new RequestDetailsViewModel(roleRequest.UserId, roleRequest.User.FirstName, roleRequest.User.LastName, 
                roleRequest.User.Email, roleRequest.User.DateOfBirth, roleRequest.Description);
        }

        public EventReportViewModel MapToEventReportViewModel(EventReport eventReport)
        {
            return new EventReportViewModel(eventReport.EventId, eventReport.User.FirstName, eventReport.User.LastName,
                eventReport.User.Email, eventReport.Description);
        }

        public EventReportIndexViewModel MapToEventReportIndexViewModel(Event eventItem)
        {
            var reportsCount = eventItem.Reports.Count;
            return new EventReportIndexViewModel(eventItem.Title, reportsCount);
        }

        public EventReportDetailsViewModel EventReportDetailsViewModel(Event eventItem, List<EventReportViewModel> eventReports)
        {
            return new EventReportDetailsViewModel(eventItem.Title, eventItem.Description, eventItem.StartTime, 
                eventItem.EndTime, eventItem.TargetAudience, eventItem.Location, eventItem.EventType, eventItem.Owner.FirstName,
                eventItem.Owner.LastName, eventItem.Owner.Email, eventReports);
        }

        public EventViewModel MapToEventViewModel(Event eventItem)
        {
            var rating = eventItem.Reviews.Average(x => x.Rating);
            return new EventViewModel(eventItem.Id, eventItem.Title, rating, eventItem.StartTime, eventItem.EventType);
        }
    }
}
