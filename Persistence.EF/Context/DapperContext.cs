using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = "Data Source=DESKTOP-G79AH4U;Initial Catalog=Ramand;Persist Security Info=True;User ID=sa;Password=Kiau@123%J;TrustServerCertificate=True;";
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
