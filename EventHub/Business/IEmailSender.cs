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

        public Task SendEventCancelationEmailAsync(string recerver, Event event);

        public Task SendEventUpdateEmailAsync(string recerver, Event event);


    }
}
