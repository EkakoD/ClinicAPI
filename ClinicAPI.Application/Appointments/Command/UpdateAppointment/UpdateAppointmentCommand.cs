﻿using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Appointments.Command.UpdateAppointment
{
    public class UpdateAppointmentCommand: IRequest<IResponse<string>>
    {
        public int AppointmentId { get; set; }
        public string Comment { get; set; }
    }
}
