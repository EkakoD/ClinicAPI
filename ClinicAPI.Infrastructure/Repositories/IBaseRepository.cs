using System;
namespace ClinicAPI.Infrastructure.Repositories
{
	public interface IBaseRepository<T> where T : class
    {
		public void Create(string tableName, string procedureName, dynamic model);
	}
}

