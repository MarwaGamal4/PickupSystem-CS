using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class EditTransActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefNum",
                table: "Transactions",
                newName: "Inv_url");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InvoiceID",
                table: "Transactions",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Invoices_InvoiceID",
                table: "Transactions",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Invoices_InvoiceID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_InvoiceID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Inv_url",
                table: "Transactions",
                newName: "RefNum");
        }
    }
}
