using System;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientCommand : IRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ActivateCode { get; set; }
    }
}

