using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoRepairShop.Api.DataContext.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.Id)
                    .IsUnicode(false)
                    .HasColumnType("bigint")
                    .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);

            builder.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(a => a.Salt)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(a => a.Cnpj)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.HasOne(a => a.RepairShop)
                .WithMany(b => b.Users)
                .HasForeignKey(a => a.IdRepairShop)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_User_RepairShop");
        }
    }
}
