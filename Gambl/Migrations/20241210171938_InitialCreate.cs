using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gambl.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseInfos",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    CourseCategory = table.Column<string>(type: "TEXT", nullable: true),
                    CourseExplain = table.Column<string>(type: "TEXT", nullable: true),
                    CourseInstructor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInfos", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "InstructorInfos",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstructorFN = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorLN = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorEmail = table.Column<string>(type: "TEXT", nullable: true),
                    InstructorPhone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorInfos", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserFN = table.Column<string>(type: "TEXT", nullable: true),
                    UserLN = table.Column<string>(type: "TEXT", nullable: true),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: true),
                    UserPhone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInfos");

            migrationBuilder.DropTable(
                name: "InstructorInfos");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
