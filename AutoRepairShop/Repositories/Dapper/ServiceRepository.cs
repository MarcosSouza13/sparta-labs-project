using AutoRepairShop.Api.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AutoRepairShop.Api.Repositories.Dapper
{
    public class ServiceRepository : IServiceRepository
    {
        readonly static string _connection = "Data Source=PC-MARCOS\\SQLEXPRESS;Initial Catalog=SpartaLabs;Integrated Security=True";

        public ServiceRepository()
        {

        }

        public async Task<int> Get(IEnumerable<int> ids)
        {
            var query = @"SELECT 
                            SUM([Service].[UnitOfWork])
                        FROM
	                        [Service]
                        JOIN 
                            [Maintenance] ON [Maintenance].[Type] = [Service].[Id]
                        WHERE
                            [Service].[Id] IN @ids";

            using (var connection = new SqlConnection(_connection))
            {
                return await connection.QueryFirstOrDefaultAsync<int>(
                    query,
                    new
                    {
                        ids = ids,
                    });
            }
        }
    }
}
