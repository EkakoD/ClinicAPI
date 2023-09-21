using System;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using ClinicAPI.Application.Users.Query.GetUserDetails;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using ClinicAPI.Application.Base;

namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtPasswordService;
        public CreateClientCommandHandler(IBaseRepository repository, IJwtPasswordService jwtPasswordService)
        {
            _repository = repository;
            _jwtPasswordService = jwtPasswordService;
        }

        public async Task<IResponse<string>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();

            var tempCodeParam = new TempCodeModel
            {
                Email = request.Email,
                Code = request.ActivateCode
            };

            var tempCodeCreateDate = _repository.GetSingle<ResponseModel>("[dbo].[GetTempCode]", tempCodeParam);
            if (tempCodeCreateDate != null)
            {
                var users = _repository.GetAll<UserResponseModel>("[dbo].[GetUserByEmail]", new ClientEmail {  Email= request.Email});
                if (users.Count() == 0)
                {
                    if (tempCodeCreateDate.CreateDate.AddMinutes(10) >= DateTime.Now)
                    {
                        var model = new CreateClientModel
                        {
                            Firstname = request.Firstname,
                            Lastname = request.Lastname,
                            Email = request.Email,
                            Password = _jwtPasswordService.HashPassword(request.Password),
                            PersonalNumber = request.PersonalNumber,
                            RoleId = 3

                        };
                        await _repository.CreateOrUpdate<CreateClientModel>("[dbo].[CreateUser]", model);
                        response.SuccessData("მოქმედება წარმატებით შესრულდა");
                    }
                    else
                    {
                        response.HasBadRequest("აქტივაციის კოდი ვადაგასულია");

                    }
                }
                else
                {
                    response.HasBadRequest("ასეთი ელ-ფოსტით უკვე შექმნილია ანგარიში");
                }
            }
            else
            {
                response.HasBadRequest("აქტივაციის კოდი ან მეილი არასწორია");
            }
            return response;
        }
    }

}