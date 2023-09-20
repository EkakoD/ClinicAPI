using System;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetDoctors
{
	public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, List<DoctorsModel>>
    {
        private IBaseRepository _repository;
        public GetDoctorsQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DoctorsModel>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            List<DoctorsModel> doctors = _repository.GetAll<DoctorsModel>("[dbo].[GetDoctors]", request);
            return doctors;
        }
    }
}

