﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Infrastructure.Repository.DbContexts;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20230512145515_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("StoreDb")
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 30);

            modelBuilder.Entity("Store.Domain.Entities.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar2(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("varchar2(300)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar2(90)")
                        .HasColumnName("Name");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("byte")
                        .HasColumnName("RecordStatus");

                    b.HasKey("Id");

                    b.HasIndex("RecordStatus");

                    b.ToTable("MainCategory", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar2(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar2(500)")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("varchar2(500)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar2(90)")
                        .HasColumnName("Name");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("byte")
                        .HasColumnName("RecordStatus");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("Stock");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("RecordStatus");

                    b.ToTable("Product", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar2(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("varchar2(300)")
                        .HasColumnName("Description");

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("MainCategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar2(90)")
                        .HasColumnName("Name");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("byte")
                        .HasColumnName("RecordStatus");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.HasIndex("RecordStatus");

                    b.ToTable("ProductCategory", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Product", b =>
                {
                    b.HasOne("Store.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Store.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Store.Domain.Entities.MainCategory", "MainCategory")
                        .WithMany()
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MainCategory");
                });
#pragma warning restore 612, 618
        }
    }
}