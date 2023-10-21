using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClinicAPI.Application.Users.Query.GetDoctors
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IResponse<List<DoctorsModel>>>
    {
        private IBaseRepository _repository;
        private string _wwwroot => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private static IHttpContextAccessor _httpContextAccessor;

        public static HttpContext Current => _httpContextAccessor.HttpContext;

        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";
        public GetDoctorsQueryHandler(IBaseRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResponse<List<DoctorsModel>>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<DoctorsModel>>();

            List<DoctorsModel> doctors = _repository.GetAll<DoctorsModel>("[dbo].[GetDoctors]", request);
            for (int i = 0; i < doctors.Count(); i++)
            {
                var folderPath = Path.Combine(_wwwroot, +doctors[i].Id + "/images");
                if (Directory.Exists(folderPath))
                {
                    var imageFolder = new DirectoryInfo(folderPath).GetFiles();
                    if (imageFolder.Count() > 0)
                    {

                        doctors[i].ImageUrl = AppBaseUrl + $"/{doctors[i].Id}/images/" +imageFolder.FirstOrDefault().Name;
                    }
                }

            }
            response.Data = doctors;
            response.SuccessData();

            return response;
        }
    }
}

