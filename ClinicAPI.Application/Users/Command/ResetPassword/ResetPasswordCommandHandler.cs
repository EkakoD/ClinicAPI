using System;
using System.Runtime.InteropServices;
using System.Text;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Command.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, string>
    {
        private IBaseRepository _repository;
        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public ResetPasswordCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = _repository.GetSingle<UserResponseModel>("[dbo].[GetUserByEmail]", request.Email);
            if (user != null)
            {
                var randomStringLength = 6;
                var randomString = new StringBuilder(randomStringLength);
                for (int i = 0; i < randomStringLength; i++)
                {
                    randomString.Append(chars[random.Next(chars.Length)]);
                }
                var newPass = randomString.ToString();

                var resetPasswordModel = new ResetPasswordModel
                {
                    Email = request.Email,
                    NewPassword = newPass
                };
                await _repository.Create<ResetPasswordModel>("[dbo].[ChangePassword]", resetPasswordModel);
                return "მოქმედება წარმატებით შესრულდა";

            }
            else
            {
                return "ამ ელ-ფოსტით მომხმარებელი არ მოიძებნა";
            }

        }
    }
}
