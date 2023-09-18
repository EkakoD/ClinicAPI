using System;
namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
}

