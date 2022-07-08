using Microsoft.EntityFrameworkCore.Migrations;

namespace DESAFIO.MVC.Migrations
{
    public partial class UpdateGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_StartPrograms_StartProgramId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_StartProgramId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "StartProgramId",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StartProgramId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_StartProgramId",
                table: "Groups",
                column: "StartProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_StartPrograms_StartProgramId",
                table: "Groups",
                column: "StartProgramId",
                principalTable: "StartPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
