using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class projectEditInfoV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectInfos_ProjectId",
                table: "ProjectInfos",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectInfos_Projects_ProjectId",
                table: "ProjectInfos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectInfos_Projects_ProjectId",
                table: "ProjectInfos");

            migrationBuilder.DropIndex(
                name: "IX_ProjectInfos_ProjectId",
                table: "ProjectInfos");
        }
    }
}
