using Microsoft.EntityFrameworkCore.Migrations;

namespace KBDataAccessLibrary.Migrations
{
    public partial class EmailWithCapital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Invitations",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Invitations",
                newName: "email");
        }
    }
}
