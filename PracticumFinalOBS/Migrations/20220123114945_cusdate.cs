using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class cusdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOP",
                table: "Membership");

            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipDate",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipDate",
                table: "Customer");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOP",
                table: "Membership",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
