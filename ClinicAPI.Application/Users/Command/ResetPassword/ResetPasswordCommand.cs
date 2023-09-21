using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Users.Command.ResetPassword
{
	public class ResetPasswordCommand :IRequest<IResponse<string>>
	{
		public string Email { get; set; }
	}
}

