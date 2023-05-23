using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.Infrastructure.Migrations.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BankingDb");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "BankingDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "BankingDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CardholderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CvvCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "BankingDb",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountNumber",
                schema: "BankingDb",
                table: "Account",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_RecordStatus",
                schema: "BankingDb",
                table: "Account",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Card_AccountId",
                schema: "BankingDb",
                table: "Card",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardNumber",
                schema: "BankingDb",
                table: "Card",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_RecordStatus",
                schema: "BankingDb",
                table: "Card",
                column: "RecordStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card",
                schema: "BankingDb");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "BankingDb");
        }
    }
}
