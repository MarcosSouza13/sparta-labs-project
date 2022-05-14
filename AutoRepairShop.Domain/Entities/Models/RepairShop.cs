using AutoRepairShop.Domain.Base;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class RepairShop : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Cnpj { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }

    }
}