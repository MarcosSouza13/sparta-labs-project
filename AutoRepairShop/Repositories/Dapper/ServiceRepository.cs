using AutoRepairShop.Api.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AutoRepairShop.Api.Repositories.Dapper
{
    public class ServiceRepository : IServiceRepository
    {
        readonly DataContext.DataContext _connection;

        public ServiceRepository(DataContext.DataContext connection)
        {
            _connection = connection;
        }

        public async Task<int> Get(long id)
        {
            var query = @"SELECT 
		                    [Service].[UnitOfWork]
                        FROM
		                    [Service]
                        WHERE
                            [Service].[Id] = @id ";

            using (var connection = new SqlConnection("Data Source=PC-MARCOS\\SQLEXPRESS;Initial Catalog=SpartaLabs;Integrated Security=True"))
            {
                return await connection.QueryFirstOrDefaultAsync<int>(
                    query,
                    new
                    {
                        id = id,
                    });
            }
        }
    }
}
