using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class UpdateCustomersPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefNum",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "CreditValue",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PlanSlogan",
                table: "planTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MealPrice",
                table: "Plans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "CustomerPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPlans_PlanId",
                table: "CustomerPlans",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPlans_Plans_PlanId",
                table: "CustomerPlans",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPlans_Plans_PlanId",
                table: "CustomerPlans");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPlans_PlanId",
                table: "CustomerPlans");

            migrationBuilder.DropColumn(
                name: "CreditValue",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PlanSlogan",
                table: "planTypes");

            migrationBuilder.DropColumn(
                name: "MealPrice",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "CustomerPlans");

            migrationBuilder.AlterColumn<int>(
                name: "RefNum",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
