using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairShop.Api.Repositories.Interfaces.Base
{
    public interface IEntityRepository<T> : IRepository<T> where T : class 
    {
        Task SaveChanges();
    }
}
