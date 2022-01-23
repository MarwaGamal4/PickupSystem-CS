using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class EditPickupSystem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Plans_PlanId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PlanId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Invoices",
                newName: "RemainingSnacks");

            migrationBuilder.AddColumn<int>(
                name: "RemainingMeals",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingMeals",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "RemainingSnacks",
                table: "Invoices",
                newName: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PlanId",
                table: "Invoices",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Plans_PlanId",
                table: "Invoices",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
