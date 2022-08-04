using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternExample.Repositories.Data
{
    public class DataContextAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class
        /// </summary>
        /// <param name="connectionString"></param>
        public DataContextAsync(string connectionString)
        {
            ConnectionString = connectionString;

            // https://stackoverflow.com/a/34536829/1506667 - How to get Dapper to ignore/remove underscores in field names when mapping
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }


        /// <summary>
        /// Gets or sets Connection string
        /// </summary>
        public string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Generic type Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnx = new MySqlConnection(ConnectionString))
            {
                return await cnx.QueryAsync<T>(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Object query
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnx = new MySqlConnection(ConnectionString))
            {
                return await cnx.QueryAsync(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Multiple type query
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnx = new MySqlConnection(ConnectionString))
            {
                return await cnx.QueryMultipleAsync(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute non reads
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection cnx = new MySqlConnection(ConnectionString))
            {
                return await cnx.ExecuteAsync(sql, param, commandType: commandType);
            }
        }

    }
}