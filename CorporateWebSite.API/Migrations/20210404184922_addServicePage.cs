using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class addServicePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "ServiceSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "ServiceSettings");
        }
    }
}
