using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class CartTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Cart_CartId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Book_CartId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CartId",
                table: "Book",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Cart_CartId",
                table: "Book",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
