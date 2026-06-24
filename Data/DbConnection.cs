using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace Insurance.Data
{
    public class DbConnection : Controller
    {
        private readonly IConfiguration _configuration;

        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Create()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }
    }
}
