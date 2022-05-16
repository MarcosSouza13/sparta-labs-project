using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Arguments.RepairShopConfiguration;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services
{
    public class RepairShopConfigurationService : IRepairShopConfigurationService
    {
        private readonly IRepairShopConfigurationRepository _repairShopConfigurationRepository;

        public RepairShopConfigurationService(IRepairShopConfigurationRepository repairShopConfigurationRepository)
        {
            _repairShopConfigurationRepository = repairShopConfigurationRepository;
        }

        public async Task<ResponseHttp<IResponse>> Add(RepairShopConfiguration repairShopConfiguration)
        {
            if (repairShopConfiguration.Date.DayOfWeek == DayOfWeek.Thursday || repairShopConfiguration.Date.DayOfWeek == DayOfWeek.Friday)
            {
                repairShopConfiguration.WorkBalance = Convert.ToInt16(repairShopConfiguration.WorkBalance * 1.3);
            }

            await _repairShopConfigurationRepository.Add(repairShopConfiguration);

            return new ResponseHttp<IResponse>(201, new ViewRepairShopConfigurationResponse(repairShopConfiguration));
        }

        public Task<ResponseHttp<IResponse>> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Edit(RepairShopConfiguration obj)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseHttp<IEnumerable<IResponse>>> List()
        {
            var list = new List<ViewRepairShopConfigurationResponse>();
            var result = await _repairShopConfigurationRepository.List();

            foreach (var item in result)
            {
                list.Add(new ViewRepairShopConfigurationResponse(item));
            }

            return new ResponseHttp<IEnumerable<IResponse>>(200, list);
        }
    }
}
