using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Users.Command.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<IResponse<string>>
    {
        public int Id { get; set; }
    }
}

