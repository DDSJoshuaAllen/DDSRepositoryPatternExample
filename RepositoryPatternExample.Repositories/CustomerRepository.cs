using RepositoryPatternExample.Models;
using RepositoryPatternExample.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternExample.Repositories
{
    public class CustomerRepository : BaseGenericRepository<Customer>
    {
        public CustomerRepository(ConnectionStrings connectionStrings) : base(connectionStrings.GetDdsMemberConnectionString())
        {
        }

        /// <summary>
        /// Example of a "complex" query
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetCustomersWithIdLessThanTwenty()
        {
            var sql = @"SELECT
                            *
                        FROM customer
                        WHERE ID < 20;";

            IEnumerable<Customer> customers = await _dataContextAsync.QueryAsync<Customer>(sql);

            return customers.ToList();
        }
    }
}
