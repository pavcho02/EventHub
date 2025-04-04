using Data.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Business
{
    public class EmailSender : IEmailSender
    {
        private readonly SendGridClient client;
        private readonly string sender;
        private readonly string senderName;

        public EmailSender(string apiKey, string sender, string senderName)
        {
            client = new SendGridClient(apiKey);
            this.sender = sender;
            this.senderName = senderName;
        }

        public async Task SendEmailAsync(string sender, string senderName, string receiver, string subject, string htmlMessage)
        {
            var from = new EmailAddress(sender, senderName);
            var to = new EmailAddress(receiver);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            await client.SendEmailAsync(msg);
        }

        public async Task SendEmailAsync(string receiver, string subject, string htmlMessage)
        {
            var from = new EmailAddress(sender, senderName);
            var to = new EmailAddress(receiver);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            await client.SendEmailAsync(msg);
        }

        public async Task SendEventCancelationEmailAsync(string receiver, Event e)
        {
            var subject = "Event Cancelation";
            var htmlMessage = $"<p>Dear {receiver},</p>" +
                $"<p>The event {e.Title} has been canceled.</p>" +
                $"<p>Feel free to search for new events in our platform</p>" +
                $"<p>Best regards,</p>" +
                $"<p>{senderName}</p>";
            await SendEmailAsync(receiver, subject, htmlMessage);
        }

        public async Task SendEventUpdateEmailAsync(string receiver, Event e)
        {
            var subject = "Event Update";
            var htmlMessage = $"<p>Dear {receiver},</p>" +
                $"<p>The event {e.Title} has been updated.</p>" +
                $"<p>{e.EventType}</p>" +
                $"<p>{e.Description}</p>" +
                $"<p>{e.Location}</p>" +
                $"<p>{e.StartTime}</p>" +
                $"<p>{e.EndTime}</p>" +
                $"<p>{e.TargetAudience}</p>" +
                $"<p>Visit EventHub platform for more information</p>" +
                $"<p>Best regards,</p>" +
                $"<p>{senderName}</p>";
            await SendEmailAsync(receiver, subject, htmlMessage);
        }

        public async Task SendEmailConfirmationAsync(string receiver, string callBackUrl)
        {
            var subject = "Email Confirmation";
            callBackUrl = HtmlEncoder.Default.Encode(callBackUrl);
            var htmlMessage = $"<p>Please confirm your account by" +
                $" <a href='{callBackUrl}'>clicking here</a>.</p>";
            await SendEmailAsync(receiver, subject, htmlMessage);
        }

        public async Task SendEmailForEventDeleteByReportAsync(string receiver, Event e)
        {
            var subject = "Event Delete";
            var htmlMessage = $"<p>Dear {receiver},</p>" +
                $"<p>The event {e.Title} has been deleted.</p>" +
                $"<p>A report was reviewed by admin and your event is violating EventHub rules.</p>" +
                $"<p>Best regards,</p>" +
                $"<p>{senderName}</p>";
            await SendEmailAsync(receiver, subject, htmlMessage);
        }
    }
}
