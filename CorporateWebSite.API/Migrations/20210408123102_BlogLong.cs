using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class BlogLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Blogs");
        }
    }
}
