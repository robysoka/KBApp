using Microsoft.EntityFrameworkCore.Migrations;

namespace KBDataAccessLibrary.Migrations
{
    public partial class FKupdaes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Classes_ClassId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AgeCategories_AgeCategoryId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Groups_GroupId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AgeCategories_AgeCategoryId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AgeCategories_AgeCategoryId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AgeCategoryId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classes_AgeCategoryId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "AgeCategoryId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AgeCategoryId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "AgeCategoryId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Classes_ClassId",
                table: "Attendances",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Groups_GroupId",
                table: "Classes",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AgeCategories_AgeCategoryId",
                table: "Groups",
                column: "AgeCategoryId",
                principalTable: "AgeCategories",
                principalColumn: "AgeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Classes_ClassId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Groups_GroupId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AgeCategories_AgeCategoryId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "AgeCategoryId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AgeCategoryId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Classes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgeCategoryId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AgeCategoryId",
                table: "Students",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_AgeCategoryId",
                table: "Classes",
                column: "AgeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Classes_ClassId",
                table: "Attendances",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AgeCategories_AgeCategoryId",
                table: "Classes",
                column: "AgeCategoryId",
                principalTable: "AgeCategories",
                principalColumn: "AgeCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Groups_GroupId",
                table: "Classes",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AgeCategories_AgeCategoryId",
                table: "Groups",
                column: "AgeCategoryId",
                principalTable: "AgeCategories",
                principalColumn: "AgeCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AgeCategories_AgeCategoryId",
                table: "Students",
                column: "AgeCategoryId",
                principalTable: "AgeCategories",
                principalColumn: "AgeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
