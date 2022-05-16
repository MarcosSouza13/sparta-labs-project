using AutoRepairShop.Api.Repositories.Interfaces;
using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Api.Validators.Base;
using AutoRepairShop.Api.Validators.RepairShop;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Arguments.RepairShop;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services
{
    public class RepairShopService : IRepairShopService
    {
        private readonly IRepairShopRepository _repairShopRepository;

        public RepairShopService(IRepairShopRepository repairShopRepository)
        {
            _repairShopRepository = repairShopRepository;
        }

        public async Task<ResponseHttp<IResponse>> Add(RepairShop repairShop)
        {
            var validator = new AddRepairShopValidator();
            var validation = validator.Validate(repairShop);
            if (!validation.IsValid)
                return new ResponseHttp<IResponse>(400, errorsModel: VisualizationError.ToList(validation.Errors));

            await _repairShopRepository.Add(repairShop);

            return new ResponseHttp<IResponse>(201, new ViewRepairShopResponse(repairShop));
        }

        public Task<ResponseHttp<IResponse>> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Edit(RepairShop repairShop)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseHttp<IResponse>> Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
