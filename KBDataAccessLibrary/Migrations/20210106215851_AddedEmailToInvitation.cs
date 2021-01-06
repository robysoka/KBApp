using Microsoft.EntityFrameworkCore.Migrations;

namespace KBDataAccessLibrary.Migrations
{
    public partial class AddedEmailToInvitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Invitations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Invitations");
        }
    }
}
