using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class AddedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    StreetAddress = table.Column<string>(type: "nvarchar2(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false),
                    StateOrProvince = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar2(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: false),
                    Building = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: true),
                    Floor = table.Column<string>(type: "nvarchar2(50)", maxLength: 50, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "StoreDb",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_City",
                schema: "StoreDb",
                table: "Address",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Country",
                schema: "StoreDb",
                table: "Address",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                schema: "StoreDb",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PostalCode",
                schema: "StoreDb",
                table: "Address",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Address_RecordStatus",
                schema: "StoreDb",
                table: "Address",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateOrProvince",
                schema: "StoreDb",
                table: "Address",
                column: "StateOrProvince");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "StoreDb");
        }
    }
}
