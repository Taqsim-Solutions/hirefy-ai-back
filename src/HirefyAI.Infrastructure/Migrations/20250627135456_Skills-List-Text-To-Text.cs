using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HirefyAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SkillsListTextToText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "Resumes",
                type: "text",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 6, 27, 13, 54, 55, 984, DateTimeKind.Utc).AddTicks(1435), new DateTime(2025, 6, 27, 13, 54, 55, 984, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RefreshToken", "RefreshTokenExpireDate" },
                values: new object[] { "2c8f265e-d4f0-4798-bb8a-6b91d6cd2499", new DateTime(2025, 6, 27, 13, 54, 55, 984, DateTimeKind.Utc).AddTicks(3003) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "Skills",
                table: "Resumes",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2025, 6, 27, 13, 37, 32, 961, DateTimeKind.Utc).AddTicks(9637), new DateTime(2025, 6, 27, 13, 37, 32, 961, DateTimeKind.Utc).AddTicks(9643) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RefreshToken", "RefreshTokenExpireDate" },
                values: new object[] { "cd7d3a31-393f-4fb9-894e-23617ea67e70", new DateTime(2025, 6, 27, 13, 37, 32, 962, DateTimeKind.Utc).AddTicks(1199) });
        }
    }
}
