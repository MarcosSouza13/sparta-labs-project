using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.RepairShop
{
    public class EditRepairShopRequest : IRequest
    {
        public EditRepairShopRequest() { }

        public EditRepairShopRequest(Domain.Entities.Models.RepairShop repairShop)
        {
            Id = repairShop.Id;
            Name = repairShop.Name;
            Cnpj = repairShop.Cnpj;
            CreatedAt = repairShop.CreatedAt;
            UpdatedAt = repairShop.UpdatedAt;
        }

        public Domain.Entities.Models.RepairShop ToRepairShop()
        {
            return new Domain.Entities.Models.RepairShop
            {
                Id = Id,
                Name = Name,
                Cnpj = Cnpj,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt
            };
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public int Cnpj { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
