using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using System;
namespace ClinicAPI.Application.Users.Command.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, string>
    {
        private IBaseRepository _repository;
        public CreateDoctorCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {

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
                return "მოქმედება წარმატებით შესრულდა";

            }
            else
            {
                return "ამ ელ-ფოსტით არსებობს უკვე ანგარიში";
            }

        }
    }
}

