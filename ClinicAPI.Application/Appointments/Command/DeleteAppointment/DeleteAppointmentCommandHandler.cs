using System;
using ClinicAPI.Application.Appointments.Command.UpdateAppointment;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtService;

        public DeleteAppointmentCommandHandler(IBaseRepository repository, IJwtPasswordService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<IResponse<string>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            var currentUserId = _jwtService.GetUserId();
            var appointment = await _repository.GetSingle<AppointmentModel>("[dbo].[GetAppointmentById]", new DeleteAppointmentModel { Id = request.Id });

            if (appointment != null && appointment.IsDeleted == false && appointment.DoctorId == currentUserId)
            {
                await _repository.CreateOrUpdate<DeleteAppointmentModel>("[dbo].[DeleteAppointment]", new DeleteAppointmentModel { Id = request.Id });


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

