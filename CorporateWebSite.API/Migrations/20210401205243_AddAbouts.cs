using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class AddAbouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info1Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info1Count = table.Column<int>(type: "int", nullable: false),
                    Info1Name = table.Column<int>(type: "int", nullable: false),
                    Info1Visible = table.Column<bool>(type: "bit", nullable: false),
                    Info2Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info2Count = table.Column<int>(type: "int", nullable: false),
                    Info2Name = table.Column<int>(type: "int", nullable: false),
                    Info2Visible = table.Column<bool>(type: "bit", nullable: false),
                    Info3Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info3Count = table.Column<int>(type: "int", nullable: false),
                    Info3Name = table.Column<int>(type: "int", nullable: false),
                    Info3Visible = table.Column<bool>(type: "bit", nullable: false),
                    Info4Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info4Count = table.Column<int>(type: "int", nullable: false),
                    Info4Name = table.Column<int>(type: "int", nullable: false),
                    Info4Visible = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "CustomInfos");
        }
    }
}
