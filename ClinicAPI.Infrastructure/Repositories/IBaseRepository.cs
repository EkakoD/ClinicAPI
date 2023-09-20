using System;
namespace ClinicAPI.Infrastructure.Repositories
{
    public interface IBaseRepository
    {
        public Task Create<T>(string procedureName, dynamic model) where T : class;
        public T GetSingle<T>(string procedureName, dynamic model) where T : new();
        public List<T> GetAll<T>(string procedureName, dynamic model) where T : new();

    }
}

