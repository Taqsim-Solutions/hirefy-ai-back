using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HirefyAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResumeEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Resumes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
