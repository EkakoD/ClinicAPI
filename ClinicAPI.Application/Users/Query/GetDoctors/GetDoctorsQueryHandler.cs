using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetDoctors
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IResponse<List<DoctorsModel>>>
    {
        private IBaseRepository _repository;
        private string _wwwroot => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public GetDoctorsQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<List<DoctorsModel>>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<DoctorsModel>>();
          
            List<DoctorsModel> doctors = _repository.GetAll<DoctorsModel>("[dbo].[GetDoctors]", request);
            for( int i=0; i<doctors.Count(); i++)
            {
                var folderPath = Path.Combine(_wwwroot, +doctors[i].Id + "/images");
                if (Directory.Exists(folderPath))
                {
                    var imageFolder = new DirectoryInfo(folderPath).GetFiles();
                    if (imageFolder.Count() > 0)
                        doctors[i].ImageUrl = imageFolder.FirstOrDefault().FullName;
                }

            }
            response.Data = doctors;
            response.SuccessData();

            return response;
        }
    }
}

