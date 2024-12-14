using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gambl.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseBuys",
                table: "CourseBuys");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseBuys",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CourseSignUpId",
                table: "CourseBuys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CourseBuys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseBuys",
                table: "CourseBuys",
                column: "CourseSignUpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseBuys",
                table: "CourseBuys");

            migrationBuilder.DropColumn(
                name: "CourseSignUpId",
                table: "CourseBuys");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CourseBuys");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseBuys",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseBuys",
                table: "CourseBuys",
                column: "CourseId");
        }
    }
}
