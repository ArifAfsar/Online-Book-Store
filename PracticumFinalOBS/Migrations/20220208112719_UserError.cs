using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class UserError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConfirmPassword",
                table: "Vendor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Customer",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConfirmPassword",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhone",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);
        }
    }
}
