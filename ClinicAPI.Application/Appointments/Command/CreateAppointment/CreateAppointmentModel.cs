using System;
namespace ClinicAPI.Application.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentModel
    {
        public int TimeId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Date { get; set; }

    }
}

