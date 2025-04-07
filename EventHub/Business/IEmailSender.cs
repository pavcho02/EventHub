using Castle.Components.DictionaryAdapter;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string sender, string senderName, 
            string receiver, string subject, string htmlMessage);

        public Task SendEmailAsync(string receiver, string subject, string htmlMessage);

        public Task SendEventCancelationEmailAsync(string recerver, Event e);

        public Task SendEventUpdateEmailAsync(string recerver, Event e);

        public Task SendEmailConfirmationAsync(string receiver, string callBackUrl);

        public Task SendEmailForEventDeleteByReportAsync(string receiver, Event e);

        public Task SendEmailForAccountRoleChangeAsync(string receiver);
    }
}
