using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Appointments.Query.GetAppointmentTimes
{
    public class GetAppointmentTimesHandler : IRequestHandler<GetAppointmentTimesQuery, IResponse<List<AppointmentTimesModel>>>
    {
        private IBaseRepository _repository;
        public GetAppointmentTimesHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<List<AppointmentTimesModel>>> Handle(GetAppointmentTimesQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<AppointmentTimesModel>>();
            List<AppointmentTimesModel> appointmentTimes = _repository.GetAll<AppointmentTimesModel>("[dbo].[GetAppointmentTimes]", request);
            response.Data = appointmentTimes;
            response.SuccessData();
            return response;
        }
    }
}

