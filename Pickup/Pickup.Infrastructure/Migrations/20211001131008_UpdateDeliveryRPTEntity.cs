using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class UpdateDeliveryRPTEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DeliveryRpt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DeliveryRpt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "DeliveryRpt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "DeliveryRpt",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DeliveryRpt");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DeliveryRpt");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "DeliveryRpt");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "DeliveryRpt");
        }
    }
}
