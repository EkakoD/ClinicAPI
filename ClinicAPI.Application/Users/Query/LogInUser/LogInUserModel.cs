using System;
namespace ClinicAPI.Application.Users.Query.LogInUser
{
    public class LogInUserModel
    {
        public string Email { get; set; }
    }

    public class ResponseModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }
    }
}

