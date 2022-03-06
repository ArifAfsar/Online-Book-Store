using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class bookdeletedescriptionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookDescription",
                table: "Book",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookDescription",
                table: "Book",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
