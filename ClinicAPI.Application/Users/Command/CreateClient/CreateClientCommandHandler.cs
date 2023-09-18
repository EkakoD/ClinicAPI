using System;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Command.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private IBaseRepository<CreateClientModel> _repository;
        public CreateClientCommandHandler(IBaseRepository<CreateClientModel> repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
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
            return null;
        }
    }
}

