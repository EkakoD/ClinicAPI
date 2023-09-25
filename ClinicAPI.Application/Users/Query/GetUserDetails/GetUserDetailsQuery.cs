using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
	public class GetUserDetailsQuery :IRequest<IResponse<UserDetailsModel>>
	{
		public int? Id { get; set; }
	}
}

