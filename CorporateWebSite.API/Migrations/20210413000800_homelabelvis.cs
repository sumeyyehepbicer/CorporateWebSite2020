using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class homelabelvis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "HomePageVisibilties");

            migrationBuilder.AddColumn<bool>(
                name: "AboutVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BandVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BlogVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BrandVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CommentVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FooterVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProjectVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServiceVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SliderVis",
                table: "HomePageVisibilties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "BandVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "BlogVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "BrandVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "CommentVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "FooterVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "NotifyVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "ProjectVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "ServiceVis",
                table: "HomePageVisibilties");

            migrationBuilder.DropColumn(
                name: "SliderVis",
                table: "HomePageVisibilties");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "HomePageVisibilties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
