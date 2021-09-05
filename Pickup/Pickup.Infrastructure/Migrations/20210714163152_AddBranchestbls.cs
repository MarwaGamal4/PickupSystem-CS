using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class AddBranchestbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserBranchesId",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserBranchesId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_UsersBranches_UserBranchesId",
                        column: x => x.UserBranchesId,
                        principalTable: "UsersBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserBranchesId",
                schema: "Identity",
                table: "Users",
                column: "UserBranchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_UserBranchesId",
                table: "Branches",
                column: "UserBranchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersBranches_UserBranchesId",
                schema: "Identity",
                table: "Users",
                column: "UserBranchesId",
                principalTable: "UsersBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersBranches_UserBranchesId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "UsersBranches");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserBranchesId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserBranchesId",
                schema: "Identity",
                table: "Users");
        }
    }
}
