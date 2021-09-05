using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickup.Infrastructure.Migrations
{
    public partial class AddEnhancedBranchestbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_UsersBranches_UserBranchesId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersBranches_UserBranchesId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserBranchesId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Branches_UserBranchesId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "UserBranchesId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserBranchesId",
                table: "Branches");

            migrationBuilder.CreateTable(
                name: "BlazorHeroUserBranch",
                columns: table => new
                {
                    BranchesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlazorHeroUserBranch", x => new { x.BranchesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BlazorHeroUserBranch_Branches_BranchesId",
                        column: x => x.BranchesId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlazorHeroUserBranch_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlazorHeroUserBranch_UsersId",
                table: "BlazorHeroUserBranch",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlazorHeroUserBranch");

            migrationBuilder.AddColumn<int>(
                name: "UserBranchesId",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserBranchesId",
                table: "Branches",
                type: "int",
                nullable: true);

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
                name: "FK_Branches_UsersBranches_UserBranchesId",
                table: "Branches",
                column: "UserBranchesId",
                principalTable: "UsersBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersBranches_UserBranchesId",
                schema: "Identity",
                table: "Users",
                column: "UserBranchesId",
                principalTable: "UsersBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
