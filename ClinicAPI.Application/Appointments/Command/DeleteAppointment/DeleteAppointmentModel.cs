using System;
namespace ClinicAPI.Application.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentModel
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

