using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Predicate;
using MySql.Data.MySqlClient;
using RepositoryPatternExample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternExample.Repositories.Data
{
    public class DataContextGenericAsync<T> : ClassMapper<T> where T : class, IEntity
    {
        private string _connectionString { get; }
        public DataContextGenericAsync(string connectionString)
        {
            _connectionString = connectionString;

            // https://stackoverflow.com/a/34536829/1506667 - How to get Dapper to ignore/remove underscores in field names when mapping
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            DapperAsyncExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();

            Map(x => x.Id).Key(KeyType.Assigned);
            AutoMap();
        }

        public async Task<int> InsertSingleAsync(T entity)
        {
            using (IDbConnection cnx = new MySqlConnection(_connectionString))
            {
                return await cnx.InsertAsync(entity);
            }
        }

        public async Task InsertManyAsync(IEnumerable<T> entities)
        {
            using (IDbConnection cnx = new MySqlConnection(_connectionString))
            {
                await cnx.InsertAsync(entities);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection cnx = new MySqlConnection(_connectionString))
            {
                IFieldPredicate idPredicate = Predicates.Field<T>(f => f.Id, Operator.Eq, id);
                var entities = await cnx.GetListAsync<T>(predicate: idPredicate);
                return entities.ToList().FirstOrDefault();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            using (IDbConnection cnx = new MySqlConnection(_connectionString))
            {
                var entities = await cnx.GetListAsync<T>();
                return entities.ToList();
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using (IDbConnection cnx = new MySqlConnection(_connectionString))
            {
                return await cnx.UpdateAsync(entity);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            using (IDbConnection cnx = new MySqlConnection(_connectionString))
            {
                return await cnx.DeleteAsync(entity);
            }
        }

    }
}
