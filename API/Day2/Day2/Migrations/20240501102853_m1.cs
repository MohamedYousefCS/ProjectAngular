using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentTempId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTemps_DepartmentTemps_DeptId",
                        column: x => x.DeptId,
                        principalTable: "DepartmentTemps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentTempId",
                table: "Student",
                column: "DepartmentTempId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTemps_DeptId",
                table: "StudentTemps",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_DepartmentTemps_DepartmentTempId",
                table: "Student",
                column: "DepartmentTempId",
                principalTable: "DepartmentTemps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_DepartmentTemps_DepartmentTempId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "StudentTemps");

            migrationBuilder.DropTable(
                name: "DepartmentTemps");

            migrationBuilder.DropIndex(
                name: "IX_Student_DepartmentTempId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DepartmentTempId",
                table: "Student");
        }
    }
}
