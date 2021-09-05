using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class AddedDeliveryRpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryRpt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRpt", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryRpt");
        }
    }
}
