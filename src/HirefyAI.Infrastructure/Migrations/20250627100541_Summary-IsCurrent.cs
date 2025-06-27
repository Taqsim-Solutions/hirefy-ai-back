using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HirefyAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SummaryIsCurrent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Experiences",
                newName: "Summary");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Resumes");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Experiences",
                newName: "Description");
        }
    }
}
