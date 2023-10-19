using System;
using FluentValidation;

namespace ClinicAPI.Application.Appointments.Command.UpdateAppointment
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ჯავშანი არ უნდა იყოს ცარიელი");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("კომენტარი არ უნდა იყოს ცარიელი");

        }
    }
}

