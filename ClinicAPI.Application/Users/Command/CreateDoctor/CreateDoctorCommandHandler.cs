using ClinicAPI.Application.Base;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using System;
namespace ClinicAPI.Application.Users.Command.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        public CreateDoctorCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();


            var users = _repository.GetAll<UserResponseModel>("[dbo].[GetUserByEmail]", request.Email);
            if (users.Count() == 0)
            {

                var model = new CreateDoctorModel
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    Password = request.Password,
                    PersonalNumber = request.PersonalNumber,
                    CategoryId = request.CategoryId,
                    RoleId = 2
                };
                await _repository.CreateOrUpdate<CreateDoctorModel>("[dbo].[CreateDoctor]", model);
                response.SuccessData("მოქმედება წარმატებით შესრულდა");

            }
            else
            {
                response.HasBadRequest("ამ ელ-ფოსტით არსებობს უკვე ანგარიში");
            }
            return response;
        }
    }
}

