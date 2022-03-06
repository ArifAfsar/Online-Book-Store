using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Book",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book",
                column: "CatagoryId",
                principalTable: "Catagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book",
                column: "CatagoryId",
                principalTable: "Catagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
