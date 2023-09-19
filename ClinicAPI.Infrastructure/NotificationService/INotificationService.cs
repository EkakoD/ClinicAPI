using ClinicAPI.Infrastructure.Models;

namespace ClinicAPI.Infrastructure.NotificationService
{
    public interface INotificationService
    {
        Task SendEmailAsync(EmailModel request);
    }
}
