using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Users.Command.SendTempCode
{
    public class SendTempCodeCommand : IRequest<IResponse<string>>
    {
        public string Email { get; set; }
    }
}

