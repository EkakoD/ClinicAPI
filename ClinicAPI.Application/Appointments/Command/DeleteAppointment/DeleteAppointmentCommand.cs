using System;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommand : MapFrom<DeleteAppointmentModel>, IRequest<int>
    {
        public int Id { get; set; }

    }
}

