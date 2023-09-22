using System;
using FluentValidation;

namespace ClinicAPI.Application.Users.Command.SendTempCode
{
    public class SendTempCodeCommandValidator : AbstractValidator<SendTempCodeCommand>
    {
        public SendTempCodeCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("ელ-ფოსტა არ უნდა იყოს ცარიელი")
                .EmailAddress().WithMessage("არ არის მეილის ფორმატი");
        }
    }
}

