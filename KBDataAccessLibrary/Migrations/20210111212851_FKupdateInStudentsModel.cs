using Microsoft.EntityFrameworkCore.Migrations;

namespace KBDataAccessLibrary.Migrations
{
    public partial class FKupdateInStudentsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Username",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Username",
                table: "Students",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Username",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Username",
                table: "Students",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
