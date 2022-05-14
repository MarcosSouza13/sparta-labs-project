using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoRepairShop.Api.DataContext.Mapping
{
    public class MaintenanceMapping : EntityTypeConfiguration<Maintenance>
    {
        public override void Map(EntityTypeBuilder<Maintenance> builder)
        {
            builder.Property(a => a.Id)
                    .IsUnicode(false)
                    .HasColumnType("bigint")
                    .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);

            builder.Property(a => a.Type)
                .IsUnicode(false);

            builder.Property(a => a.ClientName)
                .HasMaxLength(128)
                .IsUnicode(false);

            builder.Property(e => e.ScheduledAt)
                .HasColumnType("datetime");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("datetime");

            builder.HasOne(b => b.RepairShop)
            .WithMany(c => c.Maintenances)
            .HasForeignKey(b => b.IdRepairShop)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Maintenance_RepairShop");
        }
    }
}
