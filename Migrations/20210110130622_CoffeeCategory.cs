using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceShop.Migrations
{
    public partial class CoffeeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Coffee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoffeeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeCategory_Coffee_CoffeeID",
                        column: x => x.CoffeeID,
                        principalTable: "Coffee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_CustomerID",
                table: "Coffee",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCategory_CategoryID",
                table: "CoffeeCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCategory_CoffeeID",
                table: "CoffeeCategory",
                column: "CoffeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_Customer_CustomerID",
                table: "Coffee",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_Customer_CustomerID",
                table: "Coffee");

            migrationBuilder.DropTable(
                name: "CoffeeCategory");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_CustomerID",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Coffee");
        }
    }
}
