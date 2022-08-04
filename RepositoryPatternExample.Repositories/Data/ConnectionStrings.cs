using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPatternExample.Repositories.Data
{
    public class ConnectionStrings
    {
        private IConfiguration _configuration;

        public ConnectionStrings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetDdsMemberConnectionString()
        {
            return _configuration.GetConnectionString("ddsmember");
        }

    }
}