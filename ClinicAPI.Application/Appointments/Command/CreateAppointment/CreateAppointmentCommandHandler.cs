using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Users.Command.SendTempCode;
using ClinicAPI.Infrastructure.Models;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.NotificationService;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private INotificationService _notification;
        public CreateAppointmentCommandHandler(IBaseRepository repository,
            INotificationService notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<IResponse<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            var createDate = DateTime.Now;
            var model = new CreateAppointmentModel
            {
                ClientId = request.ClientId,
                DoctorId = request.DoctorId,
                Comment = request.Comment,
                TimeId = request.TimeId,
                Date = request.Date,
                CreateDate = DateTime.Now
            };
            await _repository.CreateOrUpdate<CreateAppointmentModel>("[dbo].[CreateAppointment]", model);

            response.SuccessData("მოქმედება წარმატებით შესრულდა");
            return response;
        }
    }
}

