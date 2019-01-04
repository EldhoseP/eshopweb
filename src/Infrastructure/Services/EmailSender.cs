using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var fromEmailAddress = "eShopOnWeb@demo.com";
            //Local SMTP
            MailMessage mail = new MailMessage
            {
                From = new MailAddress(fromEmailAddress),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mail.To.Add(email);

            var smtpPort = 25;
            SmtpClient smtp = new SmtpClient("localhost", smtpPort);
            smtp.UseDefaultCredentials = true;
            await smtp.SendMailAsync(mail);

            //SendGrid
            //var sendGridClient = new SendGridClient("replace-me-with-personal-sendgrid-api-key");
            //var sendGridMessage = new SendGridMessage
            //{
            //    From = new EmailAddress(fromEmailAddress),
            //    Subject = subject,
            //    HtmlContent = message
            //};
            //sendGridMessage.AddTo(email);

            //await sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}
