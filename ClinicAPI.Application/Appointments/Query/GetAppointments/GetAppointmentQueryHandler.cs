using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Appointments.Query.GetAppointments
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, IResponse<List<GetAppointmentModel>>>
    {
        private IBaseRepository _repository;
        public GetAppointmentQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<List<GetAppointmentModel>>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<GetAppointmentModel>>();
            List<GetAppointmentModel> appointmentTimes = _repository.GetAll<GetAppointmentModel>("[dbo].[GetAppointmentsWithFilters]", request);
            response.Data = appointmentTimes;
            response.SuccessData();
            return response;
        }
    }
}

