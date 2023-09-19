using System;
namespace ClinicAPI.Application.Users.Command.CreateDoctor
{
    public class CreateDoctorModel
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int CategoryId { get; set; }

    }
}

