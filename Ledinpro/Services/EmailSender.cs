using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;

namespace Ledinpro.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; set; }
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
            Options = new AuthMessageSenderOptions()
            {
                SendGridUser = "ledinpro",
                SendGridKey = "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"
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("ledinpro@163.com","ledinpro"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
