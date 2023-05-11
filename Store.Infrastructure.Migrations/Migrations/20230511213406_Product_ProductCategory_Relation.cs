using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class Product_ProductCategory_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                schema: "StoreDb",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "StoreDb",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category",
                schema: "StoreDb",
                table: "Product",
                column: "ProductCategoryId",
                principalSchema: "StoreDb",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category",
                schema: "StoreDb",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "StoreDb",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                schema: "StoreDb",
                table: "Product");
        }
    }
}
