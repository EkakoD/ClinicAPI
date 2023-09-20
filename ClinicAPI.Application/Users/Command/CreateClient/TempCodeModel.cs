using System;
namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class TempCodeModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class ResponseModel
    {
        public DateTime CreateDate { get; set; }
    }

    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public int? RoleId { get; set; }
    }

}

