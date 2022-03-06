using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class cartagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAddress = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Contact = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
