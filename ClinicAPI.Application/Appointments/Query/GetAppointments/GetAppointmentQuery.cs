using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Appointments.Query.GetAppointments
{
    public class GetAppointmentQuery : IRequest<IResponse<List<GetAppointmentModel>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}

