using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Migrations.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "StoreDb");

            migrationBuilder.CreateTable(
                name: "MainCategory",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar2(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "varchar2(300)", maxLength: 300, nullable: true),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar2(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "varchar2(300)", maxLength: 300, nullable: true),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_MainCategory",
                        column: x => x.MainCategoryId,
                        principalSchema: "StoreDb",
                        principalTable: "MainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Devart.Data.Oracle:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar2(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "varchar2(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal", maxLength: 9, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar2(500)", maxLength: 500, nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "byte", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.ProductCategoryId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainCategory_RecordStatus",
                schema: "StoreDb",
                table: "MainCategory",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "StoreDb",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RecordStatus",
                schema: "StoreDb",
                table: "Product",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MainCategory",
                schema: "StoreDb",
                table: "ProductCategory",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_RecordStatus",
                schema: "StoreDb",
                table: "ProductCategory",
                column: "RecordStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "MainCategory",
                schema: "StoreDb");
        }
    }
}
