using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gambl.Migrations
{
    /// <inheritdoc />
    public partial class InstructorsImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "InstructorImage",
                table: "InstructorInfos",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseState",
                table: "CourseInfos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorImage",
                table: "InstructorInfos");

            migrationBuilder.DropColumn(
                name: "CourseState",
                table: "CourseInfos");
        }
    }
}
