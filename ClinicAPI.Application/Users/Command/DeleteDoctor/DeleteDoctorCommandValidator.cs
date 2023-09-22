using System;
using FluentValidation;

namespace ClinicAPI.Application.Users.Command.DeleteDoctor
{
    public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID არ უნდა იყოს ცარიელი");

        }
    }
}

