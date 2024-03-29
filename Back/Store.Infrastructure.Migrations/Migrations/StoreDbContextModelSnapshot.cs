﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Infrastructure.Repository.DbContexts;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("StoreDb")
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 30);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Store.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Building")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Floor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.Property<string>("StateOrProvince")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("City");

                    b.HasIndex("Country");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PostalCode");

                    b.HasIndex("RecordStatus");

                    b.HasIndex("StateOrProvince");

                    b.ToTable("Address", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("CardType")
                        .HasColumnType("int");

                    b.Property<string>("CardholderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CvvCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.HasKey("Id");

                    b.HasIndex("CardNumber")
                        .IsUnique();

                    b.HasIndex("CardType");

                    b.HasIndex("CardholderName");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RecordStatus");

                    b.ToTable("Card", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("BirthDate");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("FirstName");

                    b.Property<int>("Gender")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PhoneNumber");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber");

                    b.HasIndex("RecordStatus");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Customer", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Name");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.HasKey("Id");

                    b.HasIndex("RecordStatus");

                    b.ToTable("MainCategory", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OrderItems")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RecordStatus");

                    b.HasIndex("Status");

                    b.ToTable("Order", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Name");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Description");

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("MainCategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Name");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.HasIndex("RecordStatus");

                    b.ToTable("ProductCategory", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreateDate");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreateUserId");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<byte>("RecordStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("RecordStatus");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

                    b.HasIndex("RecordStatus");

                    b.HasIndex("Status");

                    b.ToTable("Transaction", "StoreDb");
                });

            modelBuilder.Entity("Store.Domain.Entities.Address", b =>
                {
                    b.HasOne("Store.Domain.Entities.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Store.Domain.Entities.Card", b =>
                {
                    b.HasOne("Store.Domain.Entities.Customer", "Customer")
                        .WithMany("Cards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Store.Domain.Entities.Order", b =>
                {
                    b.HasOne("Store.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Store.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Store.Domain.Entities.Product", b =>
                {
                    b.HasOne("Store.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Store.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Store.Domain.Entities.MainCategory", "MainCategory")
                        .WithMany("ProductCategories")
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MainCategory");
                });

            modelBuilder.Entity("Store.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Store.Domain.Entities.Card", null)
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Store.Domain.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Store.Domain.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Store.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cards");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Store.Domain.Entities.MainCategory", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Store.Domain.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
