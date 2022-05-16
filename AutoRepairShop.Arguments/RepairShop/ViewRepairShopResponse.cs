using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.RepairShop
{
    public class ViewRepairShopResponse : IResponse
    {
        public ViewRepairShopResponse() { }

        public ViewRepairShopResponse(Domain.Entities.Models.RepairShop repairShop)
        {
            Id = repairShop.Id;
            Name = repairShop.Name;
            Cnpj = repairShop.Cnpj;
            CreatedAt = repairShop.CreatedAt;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
