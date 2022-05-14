using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services
{
    public class RepairShopService : IRepairShopService
    {
        public Task<ResponseHttp<IResponse>> Add(RepairShop obj)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Edit(RepairShop obj)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
