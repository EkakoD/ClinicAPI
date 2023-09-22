using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, IResponse<UserDetailsModel>>
    {
        private IBaseRepository _repository;
        public GetUserDetailsQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<UserDetailsModel>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDetailsModel>();
            UserDetailsModel details = _repository.GetSingle<UserDetailsModel>("[dbo].[GetUserById]", request);
            response.Data = details;
            response.SuccessData();
            return response;
        }
    }
}

