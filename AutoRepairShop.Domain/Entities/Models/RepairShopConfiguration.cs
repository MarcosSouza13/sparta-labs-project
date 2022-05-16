using AutoRepairShop.Domain.Base;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class RepairShopConfiguration : Entity
    {
        public long Id { get; set; }
        public long IdRepairShop { get; set; }
        public int WorkBalance { get; set; }
        public DateTime Date { get; set; }
        public RepairShop? RepairShop { get; set; }
    }
}