using System;
namespace ClinicAPI.Application.Appointments.Query.GetAppointments
{
    public class GetAppointmentModel
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        public string AppointmentTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}

