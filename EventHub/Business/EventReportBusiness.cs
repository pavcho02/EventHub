using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class EventReportBusiness : IEventReportBusiness
    {
        private readonly EventHubDbContext context;
        private readonly IEmailSender emailSender;
        public EventReportBusiness(EventHubDbContext context, IEmailSender emailSender)
        {
            this.context = context;
            this.emailSender = emailSender;
        }

        public async Task AddAsync(EventReport eventReport)
        {
            context.EventReports.Add(eventReport);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string eventId, string userId)
        {
            var eventReport = await context.EventReports.FindAsync(eventId, userId);
            if (eventReport != null)
            {
                context.EventReports.Remove(eventReport);
                await context.SaveChangesAsync();
            }
        }

        public async Task HandleReport(EventReport eventReport)
        {
            var eventInContext = await context.Events.FindAsync(eventReport.EventId);
            if (eventInContext != null)
            {
                context.Events.Remove(eventInContext);
                await context.SaveChangesAsync();

                // Send email to the event owner
                var eventOwner = await context.Users.FindAsync(eventInContext.OwnerId);
                if (eventOwner != null)
                {
                    await emailSender.SendEmailForEventDeleteByReportAsync(eventOwner.Email, eventInContext);
                }

                // Send email to participants
                var participants = await context.Participations
                    .Where(p => p.EventId == eventReport.EventId)
                    .Select(p => p.User)
                    .ToListAsync();

                foreach (var participant in participants)
                {
                    await emailSender.SendEventCancelationEmailAsync(participant.Email, eventInContext);
                }
            }
        }

        public List<TModel> GetAllReportsByEventId<TModel>(string eventId, Func<EventReport, TModel> mapFunc)
        {
            return context.EventReports.Where(er => er.EventId == eventId).Select(mapFunc).ToList();
        }
    }
}
