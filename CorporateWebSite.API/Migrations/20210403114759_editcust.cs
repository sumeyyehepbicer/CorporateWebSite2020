using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateWebSite.API.Migrations
{
    public partial class editcust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info1Count",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info1Icon",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info1Name",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info1Visible",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info2Count",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info2Icon",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info2Name",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info2Visible",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info3Count",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info3Icon",
                table: "CustomInfos");

            migrationBuilder.DropColumn(
                name: "Info3Visible",
                table: "CustomInfos");

            migrationBuilder.RenameColumn(
                name: "Info4Visible",
                table: "CustomInfos",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "Info4Name",
                table: "CustomInfos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Info4Icon",
                table: "CustomInfos",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "Info4Count",
                table: "CustomInfos",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "Info3Name",
                table: "CustomInfos",
                newName: "BgImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "CustomInfos",
                newName: "Info4Visible");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CustomInfos",
                newName: "Info4Name");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "CustomInfos",
                newName: "Info4Icon");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "CustomInfos",
                newName: "Info4Count");

            migrationBuilder.RenameColumn(
                name: "BgImageUrl",
                table: "CustomInfos",
                newName: "Info3Name");

            migrationBuilder.AddColumn<int>(
                name: "Info1Count",
                table: "CustomInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Info1Icon",
                table: "CustomInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info1Name",
                table: "CustomInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Info1Visible",
                table: "CustomInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Info2Count",
                table: "CustomInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Info2Icon",
                table: "CustomInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info2Name",
                table: "CustomInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Info2Visible",
                table: "CustomInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Info3Count",
                table: "CustomInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Info3Icon",
                table: "CustomInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Info3Visible",
                table: "CustomInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
