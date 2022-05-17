using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepairShop.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public UserRepository(DataContext.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(User user)
        {
            try
            {
                _dataContext.User.Add(user);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task Edit(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByCnpj(string cnpj)
            => await _dataContext.User.FirstOrDefaultAsync(a => a.Cnpj == cnpj);
    }
}
