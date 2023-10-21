using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Users.Query.GetUserDetails;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using MediatR;

namespace ClinicAPI.Application.Users.Query.LogInUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserForm, IResponse<ResponseModel>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtService;
        public LoginUserCommandHandler(IBaseRepository repository, IJwtPasswordService jwtPasswordService)
        {
            _repository = repository;
            _jwtService = jwtPasswordService;
        }

        public async Task<IResponse<ResponseModel>> Handle(LoginUserForm request, CancellationToken cancellationToken)
        {
            var response = new Response<ResponseModel>();
            UserDetailsModel userEmailExist = await _repository.GetSingle<UserDetailsModel>("[dbo].[GetUserByEmail]", new LogInUserModel { Email = request.Email });
            if (userEmailExist != null)
            {
                UserDetailsModel userDetails = await _repository.GetSingle<UserDetailsModel>("[dbo].[GetUserById]", new GetUserDetailsQuery { Id = userEmailExist.Id });

                var validatePassword = _jwtService.ValidatePassword(request.Password, userEmailExist.Password);
                if (validatePassword)
                {
                    var token = _jwtService.GenerateJwtToken(userDetails.Email,userDetails.RoleName, userDetails.Id);
                    response.Data = new ResponseModel { Id = userDetails.Id, Token = token, Role = userDetails.RoleName };
                    response.SuccessData();
                    return response;
                }
            }
            response.HasBadRequest("მომხმარებლის პაროლი ან ელ-ფოსტა არასწორია");
            return response;
        }
    }
}

