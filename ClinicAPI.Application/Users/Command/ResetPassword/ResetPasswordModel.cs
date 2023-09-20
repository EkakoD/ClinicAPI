using System;
namespace ClinicAPI.Application.Users.Command.ResetPassword
{
    public class ResetPasswordModel
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}

