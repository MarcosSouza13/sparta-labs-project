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
            UpdatedAt = repairShop.UpdatedAt;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Cnpj { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
