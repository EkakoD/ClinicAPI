using System;
using FluentValidation;

namespace ClinicAPI.Application.Appointments.Command.CreateAppointment
{
	public class CreateAppointmentModelValidator : AbstractValidator<CreateAppointmentModel>
	{
		public CreateAppointmentModelValidator()
		{
			RuleFor(x => x.ClientId).NotEmpty().WithMessage("მომხმარებელი არ უნდა იყოს ცარიელი");
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("ექიმი არ უნდა იყოს ცარიელი");
            RuleFor(x => x.TimeId).NotEmpty().WithMessage("დრო არ უნდა იყოს ცარიელი");
            RuleFor(x => x.Date).NotEmpty().WithMessage("თარიღი არ უნდა იყოს ცარიელი");

        }
    }
}

