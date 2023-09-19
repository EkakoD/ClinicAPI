using System;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsModel>
    {
        private IBaseRepository _repository;
        public GetUserDetailsQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDetailsModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            UserDetailsModel details = _repository.GetSingle<UserDetailsModel>("[dbo].[GetUserById]", request);
            return details;
        }
    }
}

