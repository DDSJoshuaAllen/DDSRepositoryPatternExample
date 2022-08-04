using RepositoryPatternExample.Models.Interfaces;
using RepositoryPatternExample.Repositories.Data;
using RepositoryPatternExample.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternExample.Repositories
{
    public class BaseGenericRepository<T> : IGenericRepository<T> where T: class, IEntity
    {
        public DataContextGenericAsync<T> _genericDataContextAsync;
        public DataContextAsync _dataContextAsync;

        public BaseGenericRepository(string connectionString)
        {
            _genericDataContextAsync = new DataContextGenericAsync<T>(connectionString);
            _dataContextAsync = new DataContextAsync(connectionString);
        }

        public async Task<int> InsertAsync(T entity)
        {
            return await _genericDataContextAsync.InsertSingleAsync(entity);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            return await _genericDataContextAsync.DeleteAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _genericDataContextAsync.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericDataContextAsync.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await _genericDataContextAsync.UpdateAsync(entity);
        }
    }
}
