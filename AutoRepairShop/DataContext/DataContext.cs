using AutoRepairShop.Api.DataContext.Mapping;
using AutoRepairShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public abstract class EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }

    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}

namespace AutoRepairShop.Api.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext () { }

        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {

        }

        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<RepairShop> RepairShop { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new MaintenanceMapping());
            modelBuilder.AddConfiguration(new RepairShopMapping());
            modelBuilder.AddConfiguration(new UserMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
