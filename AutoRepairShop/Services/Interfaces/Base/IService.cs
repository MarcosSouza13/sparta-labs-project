using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Api.Services.Interfaces.Base
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<ResponseHttp<IResponse>> Add(TEntity obj);
        Task<ResponseHttp<IResponse>> Edit(TEntity obj);
        Task<ResponseHttp<IResponse>> Get(long id);
        Task<ResponseHttp<IResponse>> Delete(long id);
    }
}
