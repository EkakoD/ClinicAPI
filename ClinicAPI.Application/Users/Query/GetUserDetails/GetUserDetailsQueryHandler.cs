using System;
using System.IO;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using ClinicAPI.Infrastructure.Services.JwtPasswordService;
using MediatR;

namespace ClinicAPI.Application.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, IResponse<UserDetailsModel>>
    {
        private IBaseRepository _repository;
        private IJwtPasswordService _jwtPasswordService;
        private string _wwwroot => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public GetUserDetailsQueryHandler(IBaseRepository repository, IJwtPasswordService jwtPasswordService)
        {
            _repository = repository;
            _jwtPasswordService = jwtPasswordService;
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
                    details.ImageUrl = imageFolder.FirstOrDefault().FullName;
            }
            response.Data = details;
            response.SuccessData();
            return response;
        }
    }
}

