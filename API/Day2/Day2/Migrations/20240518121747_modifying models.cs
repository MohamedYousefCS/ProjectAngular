using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2.Migrations
{
    /// <inheritdoc />
    public partial class modifyingmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_DepartmentTemps_DepartmentTempId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTemps_DepartmentTemps_DeptId",
                table: "StudentTemps");

            migrationBuilder.DropIndex(
                name: "IX_StudentTemps_DeptId",
                table: "StudentTemps");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentTempId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "StudentTemps");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "StudentTemps");

            migrationBuilder.DropColumn(
                name: "DepartmentTempId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "DepartmentTemps");

            migrationBuilder.RenameColumn(
                name: "Loc",
                table: "DepartmentTemps",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "TrackName",
                table: "StudentTemps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudents",
                table: "DepartmentTemps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackName",
                table: "StudentTemps");

            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "DepartmentTemps");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DepartmentTemps",
                newName: "Loc");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "StudentTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "StudentTemps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentTempId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "DepartmentTemps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTemps_DeptId",
                table: "StudentTemps",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentTempId",
                table: "Student",
                column: "DepartmentTempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_DepartmentTemps_DepartmentTempId",
                table: "Student",
                column: "DepartmentTempId",
                principalTable: "DepartmentTemps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTemps_DepartmentTemps_DeptId",
                table: "StudentTemps",
                column: "DeptId",
                principalTable: "DepartmentTemps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
