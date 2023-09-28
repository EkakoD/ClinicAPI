using System;
namespace ClinicAPI.Infrastructure.Repositories
{
    public interface IBaseRepository
    {
        public Task<int> CreateOrUpdate<T>(string procedureName, dynamic model) where T : class;
        public Task<T> GetSingle<T>(string procedureName, dynamic model) where T : new();
        public List<T> GetAll<T>(string procedureName, dynamic model) where T : new();

    }
}

