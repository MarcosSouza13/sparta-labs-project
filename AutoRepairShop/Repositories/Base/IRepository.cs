namespace AutoRepairShop.Api.Repositories.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task Edit(TEntity obj);
        Task<TEntity> Get(long id);
        Task Delete(TEntity obj);
    }
}
