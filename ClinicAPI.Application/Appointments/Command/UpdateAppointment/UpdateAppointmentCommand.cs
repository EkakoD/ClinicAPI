using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.UpdateAppointment
{
    public class UpdateAppointmentCommand : IRequest<IResponse<string>>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
    }

    public class AppointmentQuery
    {
        public int Id { get; set; }
    }

    public class AppointmentModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClientId { get; set; }
        public int TimeId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

