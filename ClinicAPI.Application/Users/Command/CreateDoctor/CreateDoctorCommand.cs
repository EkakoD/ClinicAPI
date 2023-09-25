using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Mappings;
using MediatR;

namespace ClinicAPI.Application.Users.Command.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<IResponse<string>>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public FileModel Image { get; set; } 
        public FileModel Pdf { get; set; } 
        public int CategoryId { get; set; }
    }
}

