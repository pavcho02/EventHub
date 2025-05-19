using Data.Models;
using EventHub.Models.InputModels;
using EventHub.Models.ViewModels;

namespace EventHub.Common.Mapping
{
    public class Mapper : IMapper
    {
        public RequestIndexViewModel MapToRequestIndexViewModel(RoleRequest roleRequest)
        {
            if (roleRequest == null)
            {
                return new RequestIndexViewModel();
            }
            else
            {
                return new RequestIndexViewModel(roleRequest.UserId, roleRequest.User.FirstName, 
                    roleRequest.User.LastName);
            }
        }

        public RequestDetailsViewModel MapToRequestDetailsViewModel(RoleRequest roleRequest)
        {
            if (roleRequest == null)
            {
                return new RequestDetailsViewModel();
            }
            else
            {
                return new RequestDetailsViewModel(roleRequest.UserId, roleRequest.User.FirstName, 
                    roleRequest.User.LastName, roleRequest.User.Email, roleRequest.User.DateOfBirth, roleRequest.Description);
            }                
        }

        public EventReportViewModel MapToEventReportViewModel(EventReport eventReport)
        {
            if (eventReport == null)
            {
                return new EventReportViewModel();
            }
            else
            {
                return new EventReportViewModel(eventReport.EventId, eventReport.UserId, eventReport.User.FirstName, eventReport.User.LastName,
                eventReport.User.Email, eventReport.Description);
            }
        }

        public EventReportIndexViewModel MapToEventReportIndexViewModel(Event eventItem)
        {
            if (eventItem == null)
            {
                return new EventReportIndexViewModel();
            }
            else
            {
                var reportsCount = eventItem.Reports.Count;
                return new EventReportIndexViewModel(eventItem.Id, eventItem.Title, reportsCount);
            }
        }

        public EventReportDetailsViewModel EventReportDetailsViewModel(Event eventItem)
        {
            if (eventItem == null || eventItem.Reports == null)
            {
                return new EventReportDetailsViewModel();
            }
            else
            {
                return new EventReportDetailsViewModel(eventItem.Id, eventItem.Title, eventItem.Description, eventItem.StartTime,
                eventItem.TargetAudience, eventItem.Location, eventItem.EventType, eventItem.Owner.FirstName,
                eventItem.Owner.LastName, eventItem.Owner.Email, eventItem.Reports.Select(x => MapToEventReportViewModel(x)).ToList());
            }
        }

        public EventViewModel MapToEventViewModel(Event eventItem)
        {
            if (eventItem == null)
            {
                return new EventViewModel();
            }
            else if (eventItem.Reviews.Count == 0)
            {
                return new EventViewModel(eventItem.Id, eventItem.Title, 0, eventItem.StartTime, eventItem.EventType);
            }
            else
            {
                var rating = eventItem.Reviews.Average(x => x.Rating);
                return new EventViewModel(eventItem.Id, eventItem.Title, rating, eventItem.StartTime, eventItem.EventType);
            }                
        }

        public EventReviewViewModel MapToEventReviewViewModel(EventReview eventReview)
        {
            if (eventReview == null)
            {
                return new EventReviewViewModel();
            }
            else
            {
                return new EventReviewViewModel(eventReview.UserId, eventReview.User.FirstName, eventReview.User.LastName,
                eventReview.EventId, eventReview.Rating, eventReview.Comment);
            }
        }

        public EventDetailsViewModel MapToEventDetailsViewModel(Event? eventItem)
        {
            if (eventItem == null)
            {
                return new EventDetailsViewModel();
            }
            else
            {
                return new EventDetailsViewModel(eventItem.Id, eventItem.Title, eventItem.Description, eventItem.StartTime,
                    eventItem.Location, eventItem.TargetAudience, eventItem.EventType,
                    eventItem.Reviews.Select(x => MapToEventReviewViewModel(x)).ToList(), eventItem.Participants);
            }
        }

        public EventInputModel MapToEventInputModel(Event eventItem)
        {
            if (eventItem == null)
            {
                return new EventInputModel();
            }
            else
            {
                return new EventInputModel(eventItem.Title, eventItem.Description, eventItem.StartTime,
                    eventItem.Location, eventItem.TargetAudience, eventItem.EventType);
            }
        }

        public EventIndexViewModel MapToEventIndexViewModel(Event eventItem)
        {
            if (eventItem == null)
            {
                return new EventIndexViewModel();
            }
            else
            {
                return new EventIndexViewModel(eventItem.Id, eventItem.Title, eventItem.EventType);
            }
        }

        public EventUpdateModel MapToEventUpdateModel(Event eventItem)
        {
            if (eventItem == null)
            {
                return new EventUpdateModel();
            }
            else
            {
                return new EventUpdateModel(eventItem.Id, eventItem.Title, eventItem.Description, eventItem.StartTime,
                    eventItem.Location, eventItem.TargetAudience, eventItem.EventType);
            }
        }
    }
}
