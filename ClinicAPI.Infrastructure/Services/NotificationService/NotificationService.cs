using System.Net;
using System.Net.Mail;
using ClinicAPI.Infrastructure.Models;

namespace ClinicAPI.Infrastructure.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        public Task SendEmailAsync(EmailModel request)
        {
            try
            {
                string body = string.Empty;
                using (MailMessage mail = new MailMessage())
                {

                    body = string.Concat(request.Text);
                    mail.From = new MailAddress("ekadaghelashvili@gmail.com");
                    mail.To.Add(request.Email);
                    mail.Subject = "Clinic Verification";
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("ekadaghelashvili@gmail.com", "mavk dkhf wfpi cnrg");
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

    }
}
