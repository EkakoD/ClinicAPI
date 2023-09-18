using System;
using FluentValidation;

namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(s => s.Firstname).NotEmpty().WithName("სახელი არ უნდა იყოს ცარიელი")
                .MinimumLength(5).WithMessage("მინიმუმ 5 სიმბოლო");
            RuleFor(s => s.Lastname).NotEmpty().WithName("გვარი არ უნდა იყოს ცარიელი");
            RuleFor(s => s.PersonalNumber).NotEmpty().WithName("პირადი ნომერი არ უნდა იყოს ცარიელი")
                .Length(11).WithMessage("11 სიმბოლო")
                .EmailAddress().WithMessage("არ არის მეილის ფორმატი");
            RuleFor(s => s.ActivateCode).NotEmpty().WithName("აქტივაციის კოდი არ უნდა იყოს ცარიელი")
                    .Length(4).WithMessage("4 ციფრი");
            RuleFor(s => s.Email).NotEmpty().WithName("ელ-ფოსტა არ უნდა იყოს ცარიელი");
            RuleFor(p => p.Password).NotEmpty().WithMessage("პაროლი არ უნდა იყოს ცარიელი")
                   .MinimumLength(8).WithMessage("მინიმუმ 8 სიმბოლო")
                   .Matches(@"[A-Z]+").WithMessage("უნდა შეიცავდეს ერთ დიდ სიმბოლოს მაინც")
                   .Matches(@"[a-z]+").WithMessage("უნდა შეიცავდეს ერთ პატარა სიმბოლოს მაინც")
                   .Matches(@"[0-9]+").WithMessage("უნდა შეიცავდეს ერთ ციფრს მაინც")
                   .Matches(@"[\!\?\*\.]+").WithMessage("უნდა შეიცავდეს ერთ სიმბოლოს(!? *.) მაინც");


        }
    }
}

