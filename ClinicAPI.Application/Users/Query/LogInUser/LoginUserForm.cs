using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Users.Query.LogInUser
{
    public class LoginUserForm : IRequest<IResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

