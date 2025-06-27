using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HirefyAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "IsDeleted", "LastModified", "LastModifiedBy", "LastName", "RefreshToken", "RefreshTokenExpireDate" },
                values: new object[] { 1, null, null, "sardorstudent0618@gmail.com", "Admin", false, null, null, "Admin", "cd7d3a31-393f-4fb9-894e-23617ea67e70", new DateTime(2025, 6, 27, 13, 37, 32, 962, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "UserId" },
                values: new object[] { 1, new DateTime(2025, 6, 27, 13, 37, 32, 961, DateTimeKind.Utc).AddTicks(9637), "System", "This is the default template for resumes.", false, new DateTime(2025, 6, 27, 13, 37, 32, 961, DateTimeKind.Utc).AddTicks(9643), "System", "Default Template", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
