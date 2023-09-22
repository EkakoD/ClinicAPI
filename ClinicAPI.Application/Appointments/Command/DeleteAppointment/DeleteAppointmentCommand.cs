using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommand : MapFrom<DeleteAppointmentModel>, IRequest<IResponse<string>>
    {
        public int Id { get; set; }

    }
}

