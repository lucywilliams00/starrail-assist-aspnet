using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarrailAssist.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LCEight",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCFive",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCFour",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCNine",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCOne",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCSeven",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCSix",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCTen",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCThree",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LCTwo",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LCEight",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCFive",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCFour",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCNine",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCOne",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCSeven",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCSix",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCTen",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCThree",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LCTwo",
                table: "Characters");
        }
    }
}
