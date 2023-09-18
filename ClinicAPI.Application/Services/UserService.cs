using System;
using ClinicAPI.Application.Users.Command.CreateClient;
using ClinicAPI.Infrastructure.Repositories;

namespace ClinicAPI.Application.Services
{
	public interface IUserService
	{
		void Create(string table,string procedure, CreateClientModel model);
	}

	public class UserService : IUserService
	{
		private readonly IBaseRepository<CreateClientModel> _repository;
		public UserService(IBaseRepository<CreateClientModel> repository)
		{
			_repository = repository;
		}

        public void Create(string table, string procedure, CreateClientModel model)
        {
			_repository.Create(table, procedure, model);
        }
    }
}

