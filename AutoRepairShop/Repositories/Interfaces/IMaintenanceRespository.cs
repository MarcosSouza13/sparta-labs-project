﻿using AutoRepairShop.Api.Repositories.Interfaces.Base;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Repositories.Interfaces
{
    public interface IMaintenanceRepository : IRepository<Maintenance>
    {
        Task<IEnumerable<Maintenance>> List();
        Task<IEnumerable<Maintenance>> ListWithDates(string initialDate, string finalDate);
    }
}
