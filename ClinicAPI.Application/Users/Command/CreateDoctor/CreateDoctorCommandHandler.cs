using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using System;
namespace ClinicAPI.Application.Users.Command.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
    {
        private IBaseRepository _repository;
        public CreateDoctorCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            //აქ უნდა შევადარო აქტივაციის კოდი თუ სწორია, დამჭირდება GetTempCode

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
            await _repository.Create<CreateDoctorModel>("[dbo].[CreateDoctor]", model);
            return Unit.Value;

        }
    }
}

