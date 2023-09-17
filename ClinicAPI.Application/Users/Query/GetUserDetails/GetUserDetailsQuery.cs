using System;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
	public class GetUserDetailsQuery :IRequest<UserDetailsModel>
	{
		public int Id { get; set; }
	}
}

