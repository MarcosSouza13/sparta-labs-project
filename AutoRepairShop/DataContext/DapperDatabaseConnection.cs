using AutoRepairShop.Api.DataContext.Interfaces;
using Microsoft.Data.SqlClient;

namespace AutoRepairShop.Api.DataContext
{
    public class DapperDatabaseConnection : IDapperDatabaseConnection
    {
        private IConfiguration _configuration;
        public DapperDatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetSection("Sql")["ConnectionString"]);
        }
    }
}
