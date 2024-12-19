using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gambl.Migrations
{
    /// <inheritdoc />
    public partial class CoursesAndInstructors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorCoursesViewModelInstructorsCoursesId",
                table: "CourseInfos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstructorCourses",
                columns: table => new
                {
                    InstructorsCoursesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCourses", x => x.InstructorsCoursesId);
                    table.ForeignKey(
                        name: "FK_InstructorCourses_InstructorInfos_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "InstructorInfos",
                        principalColumn: "InstructorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInfos_InstructorCoursesViewModelInstructorsCoursesId",
                table: "CourseInfos",
                column: "InstructorCoursesViewModelInstructorsCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourses_InstructorId",
                table: "InstructorCourses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInfos_InstructorCourses_InstructorCoursesViewModelInstructorsCoursesId",
                table: "CourseInfos",
                column: "InstructorCoursesViewModelInstructorsCoursesId",
                principalTable: "InstructorCourses",
                principalColumn: "InstructorsCoursesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInfos_InstructorCourses_InstructorCoursesViewModelInstructorsCoursesId",
                table: "CourseInfos");

            migrationBuilder.DropTable(
                name: "InstructorCourses");

            migrationBuilder.DropIndex(
                name: "IX_CourseInfos_InstructorCoursesViewModelInstructorsCoursesId",
                table: "CourseInfos");

            migrationBuilder.DropColumn(
                name: "InstructorCoursesViewModelInstructorsCoursesId",
                table: "CourseInfos");
        }
    }
}
