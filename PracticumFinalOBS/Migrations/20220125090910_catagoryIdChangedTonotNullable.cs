using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class catagoryIdChangedTonotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "CatagoryId",
                table: "Book",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book",
                column: "CatagoryId",
                principalTable: "Catagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Catagory_CatagoryId",
                table: "Book",
                column: "CatagoryId",
                principalTable: "Catagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
