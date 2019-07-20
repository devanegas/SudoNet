using Microsoft.EntityFrameworkCore.Migrations;

namespace Sudo.Migrations
{
    public partial class AddedSpeakerAndLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speaker",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Speaker",
                table: "Events");
        }
    }
}
