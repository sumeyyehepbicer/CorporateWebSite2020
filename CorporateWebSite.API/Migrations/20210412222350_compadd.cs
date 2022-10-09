using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class compadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedlnLink",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LinkedlnLink",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "Companies");
        }
    }
}
