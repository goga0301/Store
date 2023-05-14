using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class StatusForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_IsPaid",
                schema: "StoreDb",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                schema: "StoreDb",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "StoreDb",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Status",
                schema: "StoreDb",
                table: "Order",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Status",
                schema: "StoreDb",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "StoreDb",
                table: "Order");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                schema: "StoreDb",
                table: "Order",
                type: "bool",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Order_IsPaid",
                schema: "StoreDb",
                table: "Order",
                column: "IsPaid");
        }
    }
}
