﻿// <auto-generated />
using System;
using AutoRepairShop.Api.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoRepairShop.Api.Migrations
{
    [DbContext(typeof(DataContext.DataContext))]
    [Migration("20220516223854_UserSalt")]
    partial class UserSalt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.Maintenance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<long>("IdRepairShop")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("ScheduledAt")
                        .HasColumnType("datetime");

                    b.Property<int>("Type")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdRepairShop");

                    b.ToTable("Maintenance");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.RepairShop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("RepairShop");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.RepairShopConfiguration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<long>("IdRepairShop")
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    b.Property<int>("WorkBalance")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRepairShop");

                    b.ToTable("RepairShopConfiguration");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<long>("IdRepairShop")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdRepairShop");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.Maintenance", b =>
                {
                    b.HasOne("AutoRepairShop.Domain.Entities.Models.RepairShop", "RepairShop")
                        .WithMany("Maintenances")
                        .HasForeignKey("IdRepairShop")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Maintenance_RepairShop");

                    b.Navigation("RepairShop");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.RepairShopConfiguration", b =>
                {
                    b.HasOne("AutoRepairShop.Domain.Entities.Models.RepairShop", "RepairShop")
                        .WithMany("Configurations")
                        .HasForeignKey("IdRepairShop")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_RepairShopConfiguration_RepairShop");

                    b.Navigation("RepairShop");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.User", b =>
                {
                    b.HasOne("AutoRepairShop.Domain.Entities.Models.RepairShop", "RepairShop")
                        .WithMany("Users")
                        .HasForeignKey("IdRepairShop")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_User_RepairShop");

                    b.Navigation("RepairShop");
                });

            modelBuilder.Entity("AutoRepairShop.Domain.Entities.Models.RepairShop", b =>
                {
                    b.Navigation("Configurations");

                    b.Navigation("Maintenances");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
