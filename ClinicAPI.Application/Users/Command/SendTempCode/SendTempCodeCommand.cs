using System;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Users.Command.SendTempCode
{
    public class SendTempCodeCommand : IRequest
    {
        public string Email { get; set; }
    }
}

