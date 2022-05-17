using Microsoft.Data.SqlClient;

namespace AutoRepairShop.Api.DataContext.Interfaces
{
    public interface IDapperDatabaseConnection
    {
        SqlConnection GetConnection();
    }
}
