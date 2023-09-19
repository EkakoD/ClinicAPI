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
        public string ImageUrl { get; set; } // Todo: ფოტოზე მოსაფიქრებელია
        public string Pdf { get; set; } // Todo: pdf მოსაფიქრებელია
        public int CategoryId { get; set; }
        public int RoleId { get; set; }

    }
}

