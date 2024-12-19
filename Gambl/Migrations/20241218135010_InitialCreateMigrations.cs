using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gambl.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseBuys",
                columns: table => new
                {
                    CourseSignUpId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseBuys", x => x.CourseSignUpId);
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
                name: "LessonInfos",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonInfos", x => x.LessonId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserFN = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UserLN = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false),
                    UserPhone = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CourseInfos",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    CourseCategory = table.Column<string>(type: "TEXT", nullable: true),
                    CourseExplain = table.Column<string>(type: "TEXT", nullable: true),
                    CourseInstructor = table.Column<string>(type: "TEXT", nullable: true),
                    CoursePay = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseImage = table.Column<byte[]>(type: "BLOB", nullable: true),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInfos", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_CourseInfos_InstructorInfos_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "InstructorInfos",
                        principalColumn: "InstructorId");
                });

            migrationBuilder.CreateTable(
                name: "ContentInfos",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentName = table.Column<string>(type: "TEXT", nullable: true),
                    LessonInfoLessonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentInfos", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_ContentInfos_LessonInfos_LessonInfoLessonId",
                        column: x => x.LessonInfoLessonId,
                        principalTable: "LessonInfos",
                        principalColumn: "LessonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentInfos_LessonInfoLessonId",
                table: "ContentInfos",
                column: "LessonInfoLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInfos_InstructorId",
                table: "CourseInfos",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentInfos");

            migrationBuilder.DropTable(
                name: "CourseBuys");

            migrationBuilder.DropTable(
                name: "CourseInfos");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "LessonInfos");

            migrationBuilder.DropTable(
                name: "InstructorInfos");
        }
    }
}
