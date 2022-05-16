using AutoRepairShop.Api.Repositories.Interfaces.Base;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByCnpj(string cnpj);
    }
}
