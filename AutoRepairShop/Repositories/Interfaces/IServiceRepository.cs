namespace AutoRepairShop.Api.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<int> Get(IEnumerable<int> ids);
    }
}
