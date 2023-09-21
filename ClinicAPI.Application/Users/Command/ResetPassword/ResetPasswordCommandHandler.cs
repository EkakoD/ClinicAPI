using System;
using System.Runtime.InteropServices;
using System.Text;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using ClinicAPI.Infrastructure.Services.NotificationService;
using MediatR;

namespace ClinicAPI.Application.Users.Command.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private INotificationService _notificationService;
        private IJwtPasswordService _jwtPasswordService;
        private static readonly Random random = new Random();
        public ResetPasswordCommandHandler(IBaseRepository repository, INotificationService notification, IJwtPasswordService jwtPasswordService)
        {
            _repository = repository;
            _notificationService = notification;
            _jwtPasswordService = jwtPasswordService;
        }

        public async Task<IResponse<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            var user = _repository.GetSingle<UserResponseModel>("[dbo].[GetUserByEmail]", new ClientEmail { Email=request.Email});
            if (user != null)
            {
                var newPass = Guid.NewGuid().ToString("d").Substring(1, 8);

                var resetPasswordModel = new ResetPasswordModel
                {
                    Id = user.Id,
                    NewPassword = _jwtPasswordService.HashPassword(newPass)
                };
                await _repository.CreateOrUpdate<ResetPasswordModel>("[dbo].[ChangePassword]", resetPasswordModel);
                await _notificationService.SendEmailAsync(new Infrastructure.Models.EmailModel
                {
                    Email = user.Email,
                    Text = "ახალი პაროლი:"+ newPass
                });
                response.SuccessData("მოქმედება წარმატებით შესრულდა");
            }
            else
            {
                response.SuccessData("ამ ელ-ფოსტით მომხმარებელი არ მოიძებნა");
            }
            return response;
        }
    }
}
