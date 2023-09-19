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
}

