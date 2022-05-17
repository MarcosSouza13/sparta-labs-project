using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Api.Repositories
{
    public class RepairShopRepository : IRepairShopRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public RepairShopRepository(DataContext.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(RepairShop repairShop)
        {
            try
            {
                _dataContext.RepairShop.Add(repairShop);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(RepairShop obj)
        {
            throw new NotImplementedException();
        }

        public Task Edit(RepairShop obj)
        {
            throw new NotImplementedException();
        }

        public async Task<RepairShop> Get(long id)
            => await _dataContext.RepairShop.FirstOrDefaultAsync(a => a.Id == id);
    }
}
