using System;
namespace ClinicAPI.Application.Users.Command.SendTempCode
{
	public class SendTempCodeModel
	{
		public string Email { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }


    }
}

