using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.RepairShopConfiguration
{
    public class ViewRepairShopConfigurationResponse : IResponse
    {
        public ViewRepairShopConfigurationResponse() { }

        public ViewRepairShopConfigurationResponse(Domain.Entities.Models.RepairShopConfiguration repairShopConfiguration)
        {
            Id = repairShopConfiguration.Id;
            IdRepairShop = repairShopConfiguration.IdRepairShop;
            WorkBalance = repairShopConfiguration.WorkBalance;
            Date = repairShopConfiguration.Date;
        }

        public long Id { get; set; }
        public long IdRepairShop { get; set; }
        public int WorkBalance { get; set; }
        public DateTime Date { get; set; }
    }
}
