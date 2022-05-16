using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Api.Repositories
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public MaintenanceRepository(DataContext.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Maintenance maintenance)
        {
            _dataContext.Maintenance.Add(maintenance);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Edit(Maintenance maintenance)
        {
            _dataContext.Maintenance.Update(maintenance);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Maintenance> Get(long id)
            => await _dataContext.Maintenance.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Delete(Maintenance maintenance)
        {
            _dataContext.Maintenance.Remove(maintenance);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Maintenance>> List()
        {
            DateTime currentDateTime = DateTime.Today;

            var query = await _dataContext.Maintenance
                .Where(a => a.ScheduledAt >= currentDateTime).ToListAsync();

            return query;
        }

        public async Task<IEnumerable<Maintenance>> ListWithDates(string initialDate, string finalDate)
        {
            DateTime initial = Convert.ToDateTime(initialDate);
            DateTime final = Convert.ToDateTime(finalDate);

            var query = await _dataContext.Maintenance
                .Where(a => a.ScheduledAt >= initial || a.ScheduledAt <= final).ToListAsync();

            return query;
        }
    }
}
