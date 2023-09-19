using System;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private IBaseRepository<CreateClientModel> _repository;
        public CreateClientCommandHandler(IBaseRepository<CreateClientModel> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //აქ უნდა შევადარო აქტივაციის კოდი თუ სწორია, დამჭირდება GetTempCode
            var model = new CreateClientModel
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                Password = request.Password,
                PersonalNumber = request.PersonalNumber,
                RoleId = 3

            };
            _repository.Create("Users", "[dbo].[CreateUser]", model);
            return Unit.Value;
        }
    }
}

