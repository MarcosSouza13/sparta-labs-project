using AutoRepairShop.Arguments.Base;
using AutoRepairShop.Domain.Enums;

namespace AutoRepairShop.Arguments.Maintenance
{
    public class AddMaintenanceRequest : IRequest
    {
        public AddMaintenanceRequest() { }

        public AddMaintenanceRequest(Domain.Entities.Models.Maintenance maintenance)
        {
            Id = maintenance.Id;
            IdRepairShop = maintenance.IdRepairShop;
            Name = maintenance.Name;
            ClientName = maintenance.ClientName;
            Type = (int)maintenance.Type;
            ScheduledAt = maintenance.ScheduledAt;
            UpdatedAt = maintenance.UpdatedAt;
        }

        public Domain.Entities.Models.Maintenance ToMaintenance()
        {
            return new Domain.Entities.Models.Maintenance
            {
                Id = Id,
                IdRepairShop = IdRepairShop,
                Name = Name,
                ClientName = ClientName,
                Type = (ServiceType)Type,
                ScheduledAt = ScheduledAt,
                UpdatedAt = UpdatedAt
            };
        }

        public long Id { get; set; }
        public long IdRepairShop { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public int Type { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
