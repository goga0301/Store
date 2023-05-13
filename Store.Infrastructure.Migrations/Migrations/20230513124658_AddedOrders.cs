using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class AddedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    IsPaid = table.Column<bool>(type: "bool", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    OrderItems = table.Column<string>(type: "nclob", nullable: true),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "StoreDb",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "StoreDb",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                schema: "StoreDb",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "StoreDb",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IsPaid",
                schema: "StoreDb",
                table: "Order",
                column: "IsPaid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RecordStatus",
                schema: "StoreDb",
                table: "Order",
                column: "RecordStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "StoreDb");
        }
    }
}
