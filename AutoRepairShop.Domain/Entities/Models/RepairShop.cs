using AutoRepairShop.Domain.Base;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class RepairShop : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<RepairShopConfiguration> Configurations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}