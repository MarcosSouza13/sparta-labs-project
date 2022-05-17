using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoRepairShop.Api.DataContext.Mapping
{
    public class RepairShopConfigurationMapping : EntityTypeConfiguration<RepairShopConfiguration>
    {
        public override void Map(EntityTypeBuilder<RepairShopConfiguration> builder)
        {
            builder.Property(a => a.Id)
                    .IsUnicode(false)
                    .HasColumnType("bigint")
                    .ValueGeneratedOnAdd();

            builder.Property(a => a.IdRepairShop)
                .IsRequired()
                .HasColumnType("bigint")
                .IsUnicode(false);

            builder.Property(a => a.WorkBalance)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(a => a.Date)
                .HasColumnType("datetime");

            builder.HasOne(a => a.RepairShop)
                .WithMany(b => b.Configurations)
                .HasForeignKey(a => a.IdRepairShop)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_RepairShopConfiguration_RepairShop");
        }
    }
}
