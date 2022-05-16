namespace AutoRepairShop.Api.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<int> Get(long id);
    }
}
