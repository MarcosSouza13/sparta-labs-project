using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Api.Repositories
{
    public class RepairShopConfigurationRepository : IRepairShopConfigurationRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public RepairShopConfigurationRepository(DataContext.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(RepairShopConfiguration repairShopConfiguration)
        {
            _dataContext.RepairShopConfiguration.Add(repairShopConfiguration);
            await _dataContext.SaveChangesAsync();
        }

        public Task Delete(RepairShopConfiguration repairShopConfiguration)
        {
            throw new NotImplementedException();
        }

        public Task Edit(RepairShopConfiguration repairShopConfiguration)
        {
            throw new NotImplementedException();
        }

        public Task<RepairShopConfiguration> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<RepairShopConfiguration> GetByIdRepairShop(long idRepairShop, DateTime dateOfWork)
        {
            var query = await _dataContext.RepairShopConfiguration
                .FirstOrDefaultAsync(a => a.IdRepairShop == idRepairShop && a.Date.Date == dateOfWork.Date);

            return query;
        }

        public async Task<IEnumerable<RepairShopConfiguration>> List()
        {
            var currentDateTime = DateTime.Today;
            var finalDate = currentDateTime.AddDays(5);

            var query = await _dataContext.RepairShopConfiguration
                .Where(a => a.Date >= currentDateTime || a.Date <= finalDate)
                .ToListAsync();

            return query;
        }
    }
}
