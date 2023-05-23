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
                name: "Customer",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategory",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateOrProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CardholderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CvvCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_MainCatego~",
                        column: x => x.MainCategoryId,
                        principalSchema: "StoreDb",
                        principalTable: "MainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    OrderItems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 9, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_Pr~",
                        column: x => x.ProductCategoryId,
                        principalSchema: "StoreDb",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "StoreDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    RecordStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Card_CardId",
                        column: x => x.CardId,
                        principalSchema: "StoreDb",
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Customer_Custo~",
                        column: x => x.CustomerId,
                        principalSchema: "StoreDb",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "StoreDb",
                        principalTable: "Order",
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

            migrationBuilder.CreateIndex(
                name: "IX_MainCategory_RecordStatus",
                schema: "StoreDb",
                table: "MainCategory",
                column: "RecordStatus");

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
                name: "IX_Order_RecordStatus",
                schema: "StoreDb",
                table: "Order",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Status",
                schema: "StoreDb",
                table: "Order",
                column: "Status");

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
                name: "IX_ProductCategory_MainCatego~",
                schema: "StoreDb",
                table: "ProductCategory",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_RecordStat~",
                schema: "StoreDb",
                table: "ProductCategory",
                column: "RecordStatus");

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

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_RecordStatus",
                schema: "StoreDb",
                table: "Transaction",
                column: "RecordStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Status",
                schema: "StoreDb",
                table: "Transaction",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "Card",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "MainCategory",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "StoreDb");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "StoreDb");
        }
    }
}
