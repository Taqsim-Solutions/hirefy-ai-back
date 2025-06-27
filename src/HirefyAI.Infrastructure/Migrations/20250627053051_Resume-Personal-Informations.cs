using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HirefyAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResumePersonalInformations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Resumes");
        }
    }
}
