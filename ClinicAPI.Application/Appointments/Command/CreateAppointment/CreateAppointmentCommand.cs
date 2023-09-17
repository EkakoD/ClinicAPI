using System;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.CreateAppointment
{
	public class CreateAppointmentCommand :MapFrom<CreateAppointmentModel>, IRequest<int>
	{
        public int DoctorId { get; set; }
        public int ClientId { get; set; }
        public int TimeId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}

