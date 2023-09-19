using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Infrastructure.Models;

namespace ClinicAPI.Infrastructure.NotificationService
{
    public class NotificationService : INotificationService
    {
        public Task SendEmailAsync(EmailModel request)
        {
            try
            {
                //        var senderMailAddress = new MailAddress("ekaDaghelashvili@gmail.com", request.From);
                //        var receiverMailAddress = new MailAddress(request.To);

                //        SmtpClient client = new SmtpClient()
                //        {
                //            Host = "",
                //            Port = _    ,
                //            UseDefaultCredentials = false,
                //            DeliveryMethod = SmtpDeliveryMethod.Network,
                //            Credentials = new NetworkCredential(_notificationServiceOptions.Email, _notificationServiceOptions.Password),
                //            EnableSsl = true
                //        };


                //        var mail = new MailMessage();
                //        mail.From = senderMailAddress;
                //        mail.To.Add(receiverMailAddress);
                //        mail.Subject = request.Subject;
                //        mail.Body = request.Body;
                //        mail.IsBodyHtml = request.IsBodyHtml;

                //        ServicePointManager.ServerCertificateValidationCallback =
                //                   delegate (object s, X509Certificate certificate,
                //                   X509Chain chain, SslPolicyErrors sslPolicyErrors)
                //                   { return true; };

                //        client.Send(mail);
                return Task.CompletedTask;
                //    }
                //    catch (Exception ex)
                //    {
                //        return Task.FromException(ex);
                //    }
            }

    }
    }
