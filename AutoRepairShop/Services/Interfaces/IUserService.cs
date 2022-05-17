using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces.Base;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<ResponseHttp<IResponse>> Login(Login login);
    }
}
