using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.Maintenance
{
    public class ViewMaintenanceResponse : IResponse
    {
        public ViewMaintenanceResponse() { }

        public ViewMaintenanceResponse(Domain.Entities.Models.Maintenance maintenance)
        {
            Id = maintenance.Id;
            IdRepairShop = maintenance.IdRepairShop;
            Name = maintenance.Name;
            ClientName = maintenance.ClientName;
            Type = maintenance.Type.ToString();
            ScheduledAt = maintenance.ScheduledAt;
            UpdatedAt = maintenance.UpdatedAt;
        }

        public long Id { get; set; }
        public long IdRepairShop { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Type { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
