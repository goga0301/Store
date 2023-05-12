using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class removeAddressInCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "StoreDb",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "StoreDb",
                table: "Customer",
                type: "varchar2(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
