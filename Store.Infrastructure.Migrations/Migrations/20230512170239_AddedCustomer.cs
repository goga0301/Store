using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class AddedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    FirstName = table.Column<string>(type: "varchar2(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar2(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar2(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "varchar2(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar2(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "varchar2(10)", maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                schema: "StoreDb",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PhoneNumber",
                schema: "StoreDb",
                table: "Customer",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RecordStatus",
                schema: "StoreDb",
                table: "Customer",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserName",
                schema: "StoreDb",
                table: "Customer",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "StoreDb");
        }
    }
}
