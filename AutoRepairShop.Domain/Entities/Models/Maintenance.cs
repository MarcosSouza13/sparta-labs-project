using AutoRepairShop.Domain.Base;
using AutoRepairShop.Domain.Enums;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class Maintenance : Entity
    {
        public long Id { get; set; }
        public long IdRepairShop { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public ServiceType Type { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public RepairShop? RepairShop { get; set; }
    }
}
