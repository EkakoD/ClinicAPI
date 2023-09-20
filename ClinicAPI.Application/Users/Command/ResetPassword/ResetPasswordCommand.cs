using System;
using MediatR;

namespace ClinicAPI.Application.Users.Command.ResetPassword
{
	public class ResetPasswordCommand :IRequest<string>
	{
		public string Email { get; set; }
	}
}

