using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApplicatie.Migrations
{
    /// <inheritdoc />
    public partial class ClassGroupLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassGroupId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassGroupId",
                table: "Students",
                column: "ClassGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassGroups_ClassGroupId",
                table: "Students",
                column: "ClassGroupId",
                principalTable: "ClassGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassGroups_ClassGroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassGroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassGroupId",
                table: "Students");
        }
    }
}
