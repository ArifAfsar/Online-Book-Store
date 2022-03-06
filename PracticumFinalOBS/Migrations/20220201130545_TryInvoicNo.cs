using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticumFinalOBS.Migrations
{
    public partial class TryInvoicNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionCode",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "TransactionCode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
