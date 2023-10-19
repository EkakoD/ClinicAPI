using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtService;

        public UpdateAppointmentCommandHandler(IBaseRepository repository,
            IJwtPasswordService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<IResponse<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            var currentUserId = _jwtService.GetUserId();
            var appointment = await _repository.GetSingle<AppointmentModel>("[dbo].[GetAppointmentById]", new AppointmentQuery { Id = request.Id });
            if (appointment != null && appointment.DoctorId == currentUserId)
            {
                await _repository.CreateOrUpdate<UpdateAppointmentCommand>("[dbo].[UpdateAppointment]", request);

                response.SuccessData("მოქმედება წარმატებით შესრულდა");
            }
            else
            {
                response.NotFoundData("ექიმის ჯავშანი არ მოიძებნა");
            }

            return response;
        }
    }
}

