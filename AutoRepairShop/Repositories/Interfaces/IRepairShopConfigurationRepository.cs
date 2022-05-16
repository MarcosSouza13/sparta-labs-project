using AutoRepairShop.Api.Repositories.Interfaces.Base;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Repositories.Interfaces
{
    public interface IRepairShopConfigurationRepository : IRepository<RepairShopConfiguration>
    {
        Task<RepairShopConfiguration> GetByIdRepairShop(long idRepairShop, DateTime dateofWork);
        Task<IEnumerable<RepairShopConfiguration>> List();
    }
}
