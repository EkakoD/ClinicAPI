using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.NotificationService;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private INotificationService _notification;
        public UpdateAppointmentCommandHandler(IBaseRepository repository,
            INotificationService notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<IResponse<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();

            await _repository.CreateOrUpdate<UpdateAppointmentCommand>("[dbo].[UpdateAppointment]", request);

            response.SuccessData("მოქმედება წარმატებით შესრულდა");
            return response;
        }
    }
}

