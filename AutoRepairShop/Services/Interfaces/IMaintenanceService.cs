using AutoRepairShop.Api.Services.Base;
using AutoRepairShop.Api.Services.Interfaces.Base;
using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Domain.Entities.Models;

namespace AutoRepairShop.Api.Services.Interfaces
{
    public interface IMaintenanceService : IService<Maintenance>
    {
        Task<ResponseHttp<IEnumerable<IResponse>>> List();
        Task<ResponseHttp<IEnumerable<IResponse>>> ListDaily();
        Task<ResponseHttp<IEnumerable<IResponse>>> ListWithDates(string initialDate, string finalDate);
    }
}
