using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class quantityChangedToNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Book",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Book",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
