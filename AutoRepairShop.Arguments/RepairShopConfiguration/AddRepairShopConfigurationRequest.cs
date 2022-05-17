using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.RepairShopConfiguration
{
    public class AddRepairShopConfigurationRequest : IRequest
    {
        public AddRepairShopConfigurationRequest() { }

        public AddRepairShopConfigurationRequest(Domain.Entities.Models.RepairShopConfiguration repairShopConfiguration)
        {
            Id = repairShopConfiguration.Id;
            IdRepairShop = repairShopConfiguration.IdRepairShop;
            WorkBalance = repairShopConfiguration.WorkBalance;
            Date = repairShopConfiguration.Date;
        }

        public Domain.Entities.Models.RepairShopConfiguration ToRepairShopConfiguration()
        {
            return new Domain.Entities.Models.RepairShopConfiguration
            {
                Id = Id,
                IdRepairShop = IdRepairShop,
                WorkBalance = WorkBalance,
                Date = Date
            };
        }

        public long Id { get; set; }
        public long IdRepairShop { get; set; }
        public int WorkBalance { get; set; }
        public DateTime Date { get; set; }
    }
}
