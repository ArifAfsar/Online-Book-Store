using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class PcAfterCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Book",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Book",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
