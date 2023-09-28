using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Users.Command.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, IResponse<string>>
    {
        private IBaseRepository _repository;
        public DeleteDoctorCommandHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<string>();
            var appointment = await _repository.GetSingle<UserResponseModel>("[dbo].[GetUserById]", new DeleteDoctorModel { Id = request.Id });
            if (appointment != null && appointment.IsDeleted == false)
            {
                await _repository.CreateOrUpdate<DeleteDoctorModel>("[dbo].[DeleteDoctor]", new DeleteDoctorModel { Id = request.Id });
                response.SuccessData("მოქმედება წარმატებით შესრულდა");
            }
            else
            {
                response.NotFoundData("ექიმი არ მოიძებნა");
            }
            return response;
        }
    }
}

