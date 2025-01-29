using Data;
using Data.Models;

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
            this.context.EventReports.Add(eventReport);
            await this.context.SaveChangesAsync();
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
    }
}
