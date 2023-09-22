using ClinicAPI.Infrastructure.Models;
using ClinicAPI.Infrastructure.Services.NotificationService;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using System;
using ClinicAPI.Application.Base;

namespace ClinicAPI.Application.Users.Command.SendTempCode
{
    public class SendTempCodeCommandHandler : IRequestHandler<SendTempCodeCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private INotificationService _notification;
        public SendTempCodeCommandHandler(IBaseRepository repository,
            INotificationService notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<IResponse<string>> Handle(SendTempCodeCommand request, CancellationToken cancellationToken)
        {
            Random random = new Random();
            var response = new Response<string>();

            int code = random.Next(1000, 10000);

            var codeString = code.ToString();
            var createDate = DateTime.Now;
            var model = new SendTempCodeModel
            {
                Email = request.Email,
                Code = codeString,
                CreateDate = createDate
            };
            await _repository.CreateOrUpdate<SendTempCodeModel>("[dbo].[CreateTempCode]", model);

            EmailModel emailModel = new EmailModel
            {
                Email = request.Email,
                Text = "ვერიფიკაციის კოდი:" + codeString,
            };

            await _notification.SendEmailAsync(emailModel);
            response.SuccessData("მოქმედება წარმატებით შესრულდა");
            return response;
        }
    }
}

