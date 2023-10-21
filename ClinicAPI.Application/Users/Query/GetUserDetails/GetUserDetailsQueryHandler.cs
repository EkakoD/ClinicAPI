using System;
using System.IO;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, IResponse<UserDetailsModel>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtPasswordService;
        private string _wwwroot => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private static IHttpContextAccessor _httpContextAccessor;

        public static HttpContext Current => _httpContextAccessor.HttpContext;

        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";
        public GetUserDetailsQueryHandler(IBaseRepository repository, IJwtPasswordService jwtPasswordService, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _jwtPasswordService = jwtPasswordService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResponse<UserDetailsModel>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDetailsModel>();
            UserDetailsModel details = await _repository.GetSingle<UserDetailsModel>("[dbo].[GetUserById]", new GetUserDetailsQuery { Id = request.Id });
            var folderPath = Path.Combine(_wwwroot, +details.Id + "/images");

            if (Directory.Exists(folderPath))
            {
                var imageFolder = new DirectoryInfo(folderPath).GetFiles();

                if (imageFolder.Count() > 0)
                    details.ImageUrl = AppBaseUrl + $"/{details.Id}/images/" + imageFolder.FirstOrDefault().Name;
            }
            response.Data = details;
            response.SuccessData();
            return response;
        }
    }
}

