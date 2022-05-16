using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.RepairShop
{
    public class AddRepairShopRequest : IRequest
    {
        public AddRepairShopRequest() { }

        public AddRepairShopRequest(Domain.Entities.Models.RepairShop repairShop)
        {
            Id = repairShop.Id;
            Name = repairShop.Name;
            Cnpj = repairShop.Cnpj;
            CreatedAt = repairShop.CreatedAt;
        }

        public Domain.Entities.Models.RepairShop ToRepairShop()
        {
            return new Domain.Entities.Models.RepairShop
            {
                Id = Id,
                Name = Name,
                Cnpj = Cnpj,
                CreatedAt = DateTime.Now,
            };
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
