using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebService.Infrascture.Migrations
{
    public partial class init01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    Customer = table.Column<string>(maxLength: 30, nullable: false),
                    SiteName = table.Column<string>(maxLength: 30, nullable: false),
                    SiteUrl = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Product_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Path = table.Column<string>(maxLength: 500, nullable: false),
                    Product_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Images_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Product_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Services_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Product_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tags_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Customer", "Delete", "Description", "EndDate", "SiteName", "SiteUrl", "StartDate" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), "Shrine vast", false, "Relief oft feels to his tales earth would love paphian might of light rake sore none me his flatterers might", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The to a one virtues", "https://Tests.com", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), false, "Designe", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), false, "Develope", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000000"), false, "Host", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("40000000-0000-0000-0000-000000000000"), false, "Support", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "Delete", "Name", "Path", "Product_ID" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), false, "01.jpg", "/images/gallery/Test/", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "Delete", "Name", "Path", "Product_ID" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), false, "02.jpg", "/images/gallery/Test/", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "Delete", "Name", "Path", "Product_ID" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000000"), false, "03.jpg", "/images/gallery/Test/", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "Delete", "Name", "Path", "Product_ID" },
                values: new object[] { new Guid("40000000-0000-0000-0000-000000000000"), false, "04.jpg", "/images/gallery/Test/", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "Delete", "Name", "Path", "Product_ID" },
                values: new object[] { new Guid("50000000-0000-0000-0000-000000000000"), false, "05.jpg", "/images/gallery/Test/", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "Delete", "Name", "Path", "Product_ID" },
                values: new object[] { new Guid("60000000-0000-0000-0000-000000000000"), false, "06.jpg", "/images/gallery/Test/", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("50000000-0000-0000-0000-000000000000"), false, "Support Long Time WebSite", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("40000000-0000-0000-0000-000000000000"), false, "Expandable in the online store", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), false, "Product Management", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), false, "Product Information", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000000"), false, "Admin panel", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("50000000-0000-0000-0000-000000000000"), false, "Ecommerce", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000000"), false, ".NetCore", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000000"), false, "C#", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("30000000-0000-0000-0000-000000000000"), false, "Designer", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("40000000-0000-0000-0000-000000000000"), false, "Developer", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Delete", "Name", "Product_ID" },
                values: new object[] { new Guid("60000000-0000-0000-0000-000000000000"), false, "WebShop", new Guid("10000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Product_ID",
                table: "Categories",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Product_ID",
                table: "Images",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Product_ID",
                table: "Services",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Product_ID",
                table: "Tags",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
