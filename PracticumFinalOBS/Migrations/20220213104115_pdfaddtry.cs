using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class pdfaddtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Online",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    pdf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Online", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Online");
        }
    }
}
