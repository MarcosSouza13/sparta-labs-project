namespace AutoRepairShop.Api.Repositories.Interfaces.Base
{
    public interface IEntityRepository<T> : IRepository<T> where T : class
    {
        Task SaveChanges();
    }
}
