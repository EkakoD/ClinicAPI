using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetDoctors
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IResponse<List<DoctorsModel>>>
    {
        private IBaseRepository _repository;
        public GetDoctorsQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<List<DoctorsModel>>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<DoctorsModel>>();

            List<DoctorsModel> doctors = _repository.GetAll<DoctorsModel>("[dbo].[GetDoctors]", request);
            response.Data = doctors;
            response.SuccessData();

            return response;
        }
    }
}

