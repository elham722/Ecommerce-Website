﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopCenter.Persistence.Context;

#nullable disable

namespace ShopCenter.Persistence.Migrations
{
    [DbContext(typeof(ShopCenterDbContext))]
    [Migration("20241115135206_seeddatanew")]
    partial class seeddatanew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopCenter.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 11, 15, 17, 22, 5, 759, DateTimeKind.Local).AddTicks(4822),
                            Password = "Elh@m3605",
                            UserName = "Vacations"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 11, 15, 17, 22, 5, 760, DateTimeKind.Local).AddTicks(2885),
                            Password = "123456",
                            UserName = "Eli"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
