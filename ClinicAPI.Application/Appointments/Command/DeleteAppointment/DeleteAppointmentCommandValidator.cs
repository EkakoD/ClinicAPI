using System;
using FluentValidation;

namespace ClinicAPI.Application.Appointments.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommand>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID არ უნდა იყოს ცარიელი");
        }
    }
}

