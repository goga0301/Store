using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class checkForIndexes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transaction_CardId",
                schema: "StoreDb",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CustomerId",
                schema: "StoreDb",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_OrderId",
                schema: "StoreDb",
                table: "Transaction");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CardId",
                schema: "StoreDb",
                table: "Transaction",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerId",
                schema: "StoreDb",
                table: "Transaction",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OrderId",
                schema: "StoreDb",
                table: "Transaction",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transaction_CardId",
                schema: "StoreDb",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CustomerId",
                schema: "StoreDb",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_OrderId",
                schema: "StoreDb",
                table: "Transaction");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CardId",
                schema: "StoreDb",
                table: "Transaction",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustomerId",
                schema: "StoreDb",
                table: "Transaction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OrderId",
                schema: "StoreDb",
                table: "Transaction",
                column: "OrderId");
        }
    }
}
