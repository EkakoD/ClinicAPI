using ClinicAPI.Infrastructure.Repositories;
using MediatR;
using System;
namespace ClinicAPI.Application.Users.Command.SendTempCode
{
    public class SendTempCodeCommandHandler : IRequestHandler<SendTempCodeCommand>
    {
        private IBaseRepository<SendTempCodeModel> _repository;
        public SendTempCodeCommandHandler(IBaseRepository<SendTempCodeModel> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SendTempCodeCommand request, CancellationToken cancellationToken)
        {
            Random random = new Random();

            int code = random.Next(1000, 10000);

            string codeString = code.ToString("D4");
            var createDate = DateTime.Now;
            var model = new SendTempCodeModel
            {
                Email = request.Email,
                Code = codeString,
                CreateDate = createDate
            };

            _repository.Create("Users", "[dbo].[CreateDoctor]", model);
            //აქ უნდა გავაგზავნო მეილზე მესიჯი

            return Unit.Value;
        }
    }
}

