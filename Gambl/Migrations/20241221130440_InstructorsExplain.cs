using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gambl.Migrations
{
    /// <inheritdoc />
    public partial class InstructorsExplain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorExplain",
                table: "InstructorInfos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorExplain",
                table: "InstructorInfos");
        }
    }
}
