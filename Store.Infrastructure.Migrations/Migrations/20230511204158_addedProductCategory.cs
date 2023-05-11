using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class addedProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "StoreDb",
                table: "Product",
                type: "decimal",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "StoreDb",
                table: "Product",
                type: "nclob",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "StoreDb",
                table: "Product",
                type: "nclob",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "StoreDb",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    Name = table.Column<string>(type: "nclob", nullable: false),
                    Description = table.Column<string>(type: "nclob", nullable: true),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "nclob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "StoreDb");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "StoreDb",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "StoreDb",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "StoreDb",
                table: "Product");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "StoreDb",
                table: "Product",
                type: "decimal",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldNullable: true);
        }
    }
}
