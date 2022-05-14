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
                .HasMaxLength(36)
                .IsUnicode(false);

            builder.Property(a => a.Cnpj)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);
        }
    }
}
