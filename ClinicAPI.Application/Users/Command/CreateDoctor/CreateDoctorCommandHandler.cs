using ClinicAPI.Application.Base;
using ClinicAPI.Application.Files;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using MediatR;
using System;
namespace ClinicAPI.Application.Users.Command.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtPasswordService;

        public CreateDoctorCommandHandler(IBaseRepository repository, IJwtPasswordService jwtPasswordService)
        {
            _repository = repository;
            _jwtPasswordService = jwtPasswordService;
        }

        public async Task<IResponse<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();


            var users = _repository.GetAll<UserResponseModel>("[dbo].[GetUserByEmail]", new DoctorEmail { Email = request.Email });
            if (users.Count() == 0)
            {
                var model = new CreateDoctorModel
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    Password = _jwtPasswordService.HashPassword(request.Password),
                    PersonalNumber = request.PersonalNumber,
                    CategoryId = request.CategoryId,
                    RoleId = 2
                };
                var id = await _repository.CreateOrUpdate<CreateDoctorModel>("[dbo].[CreateDoctor]", model);
                request.Pdf.InsertFile (id, "cv");
                request.Image.InsertFile(id, "images");
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

