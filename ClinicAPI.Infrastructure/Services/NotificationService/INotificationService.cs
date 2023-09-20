using ClinicAPI.Infrastructure.Models;

namespace ClinicAPI.Infrastructure.Services.NotificationService
{
    public interface INotificationService
    {
        Task SendEmailAsync(EmailModel request);
    }
}
