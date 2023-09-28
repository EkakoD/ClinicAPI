using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        public DeleteAppointmentCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<string>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            var appointment = await _repository.GetSingle<AppointmentModel>("[dbo].[GetAppointmentById]", new DeleteAppointmentModel { Id = request.Id });
            if (appointment != null && appointment.IsDeleted == false)
            {
                await _repository.CreateOrUpdate<DeleteAppointmentModel>("[dbo].[DeleteAppointment]", new DeleteAppointmentModel { Id = request.Id });
                response.SuccessData("მოქმედება წარმატებით შესრულდა");
            }
            else
            {
                response.NotFoundData("ჯავშანი არ მოიძებნა");
            }
            return response;
        }
    }
}

