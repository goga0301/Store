using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class addedCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar2(16)", maxLength: 16, nullable: false),
                    CardholderName = table.Column<string>(type: "nvarchar2(100)", maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CvvCode = table.Column<string>(type: "nvarchar2(3)", maxLength: 3, nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "StoreDb",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardholderName",
                schema: "StoreDb",
                table: "Card",
                column: "CardholderName");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardNumber",
                schema: "StoreDb",
                table: "Card",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardType",
                schema: "StoreDb",
                table: "Card",
                column: "CardType");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CustomerId",
                schema: "StoreDb",
                table: "Card",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_RecordStatus",
                schema: "StoreDb",
                table: "Card",
                column: "RecordStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card",
                schema: "StoreDb");
        }
    }
}
