using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class AddDilevryDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sender_from_driver",
                table: "DeliveryRpt",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sender_from_driver",
                table: "DeliveryRpt");
        }
    }
}
