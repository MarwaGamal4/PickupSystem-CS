using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class EditPickupSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPlans_Branches_BranchId",
                table: "CustomerPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPlans_Plans_PlanId",
                table: "CustomerPlans");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPlans_BranchId",
                table: "CustomerPlans");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "CustomerPlans");

            migrationBuilder.RenameColumn(
                name: "TotalMealsCounr",
                table: "Invoices",
                newName: "TotalMealsCount");

            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "Invoices",
                newName: "SnacksAmount");

            migrationBuilder.RenameColumn(
                name: "Discountvalue",
                table: "Invoices",
                newName: "MealsAmount");

            migrationBuilder.AddColumn<int>(
                name: "PickupLogId",
                table: "Inv_Images",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "CustomerPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PickupLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    POS_res_Id = table.Column<int>(type: "int", nullable: false),
                    MealsCount = table.Column<int>(type: "int", nullable: false),
                    SnacksCount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickupLogs_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PickupLogs_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PickupLogs_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Images_PickupLogId",
                table: "Inv_Images",
                column: "PickupLogId");

            migrationBuilder.CreateIndex(
                name: "IX_PickupLogs_BranchID",
                table: "PickupLogs",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_PickupLogs_CustomerID",
                table: "PickupLogs",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PickupLogs_InvoiceID",
                table: "PickupLogs",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPlans_Plans_PlanId",
                table: "CustomerPlans",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Images_PickupLogs_PickupLogId",
                table: "Inv_Images",
                column: "PickupLogId",
                principalTable: "PickupLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPlans_Plans_PlanId",
                table: "CustomerPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Images_PickupLogs_PickupLogId",
                table: "Inv_Images");

            migrationBuilder.DropTable(
                name: "PickupLogs");

            migrationBuilder.DropIndex(
                name: "IX_Inv_Images_PickupLogId",
                table: "Inv_Images");

            migrationBuilder.DropColumn(
                name: "PickupLogId",
                table: "Inv_Images");

            migrationBuilder.RenameColumn(
                name: "TotalMealsCount",
                table: "Invoices",
                newName: "TotalMealsCounr");

            migrationBuilder.RenameColumn(
                name: "SnacksAmount",
                table: "Invoices",
                newName: "Tax");

            migrationBuilder.RenameColumn(
                name: "MealsAmount",
                table: "Invoices",
                newName: "Discountvalue");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "CustomerPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "CustomerPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPlans_BranchId",
                table: "CustomerPlans",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPlans_Branches_BranchId",
                table: "CustomerPlans",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPlans_Plans_PlanId",
                table: "CustomerPlans",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
